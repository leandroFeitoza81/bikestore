using System.Data;
using BikeStore.Application.Exceptions;
using BikeStore.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Repositories;

public abstract class RepositoryBase<TModel>(string connectionString)
{
    
    private SqlConnection connection;
    private async Task<SqlConnection> GetConnectionAsync()
    {
        var dbConnection = new SqlConnection(connectionString);
        await dbConnection.OpenAsync();
        return dbConnection;
    }
    
    private async Task EnsureConnectionOpened()
    {
        connection = await GetConnectionAsync();
        
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }
    
    protected async Task<List<T?>> ExecuteQueryToListAsync<T>(string query,
        Dictionary<string, object>? parameters = null) where T : class
    {
        await EnsureConnectionOpened();
        
        var result = new List<T?>();

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = query;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }
            }

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(MapProductWithDetail(reader) as T);
            }

            return result;
        }
        catch (SqlException ex)
        {
            //TODO
            // Implantar log
            throw new DataBaseException("Erro ao acessar os dados.", ex);
        }
        catch (Exception ex)
        {
            //TODO
            // Implantar log
            throw;
        }
    }

    private Product MapProductWithDetail(SqlDataReader reader)
    {
        var product = new Product()
        {
            ProductId = reader["ProductId"] is DBNull ? 0 : (int)reader["ProductId"],
            ProductName = reader["ProductName"] is DBNull ? string.Empty : reader["ProductName"].ToString(),
            Price = reader["ListPrice"] is DBNull ? 0 : (decimal)reader["ListPrice"],
            ModelYear = (short)(reader["ModelYear"] is DBNull ? 0 : (short)reader["ModelYear"]),
            Brand = new Brand()
            {
                BrandName = reader["BrandName"] is DBNull ? string.Empty : reader["BrandName"].ToString()
            },
            Category = new Category()
            {
                CategoryName = reader["CategoryName"] is DBNull ? string.Empty : reader["CategoryName"].ToString()
            }
        };
        
        return product;
    }
}