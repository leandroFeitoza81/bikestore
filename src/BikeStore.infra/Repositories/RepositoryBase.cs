using System.Data;
using BikeStore.Application.Exceptions;
using BikeStore.Infra.Mappers.Interfaces;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Repositories;

public abstract class RepositoryBase : IDisposable
{
    private readonly string connectionString;
    private SqlConnection? _connection;
    
    protected RepositoryBase(string connectionString)
    {
        this.connectionString = connectionString;
    }
    
    private  async Task<SqlConnection> GetConnectionAsync()
    {
        _connection ??= new SqlConnection(connectionString);

        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();

        return _connection;
    }

    protected async Task<List<T>> ExecuteQueryToListAsync<T>(
        string query,
        IEntityMapper<T> mapper,
        Dictionary<string, object>? parameters = null) where T : class
    {
        var dbConnection = await GetConnectionAsync();
        var result = new List<T>();

        try
        {
            await using var command = dbConnection.CreateCommand();
            command.CommandText = query;
            
            AddParameters(command, parameters);
            
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(mapper.Map(reader));
            }
            
            return result;

        }
        catch (SqlException ex)
        {
            throw new DataBaseException("Erro para acessar os dados", ex);
        }
    }
    
    protected async Task<T?> ExecuteQueryFirstOrDefaultAsync<T>(
        string query,
        IEntityMapper<T> mapper,
        Dictionary<string, object>? parameters = null) where T : class
    {
        var dbConnection = await GetConnectionAsync();

        try
        {
            await using var command = dbConnection.CreateCommand();
            command.CommandText = query;
            
            AddParameters(command, parameters);

            await using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
                return mapper.Map(reader);
            
            return null;
        }
        catch (Exception ex)
        {
            throw new DataBaseException("Erro para acessar os dados", ex);
        }
    }

    protected async Task<int> ExecuteInsertAsync(string query, Dictionary<string, object>? parameters = null)
    {
        var dbConnection = await GetConnectionAsync();
        try
        {
            await using var command = dbConnection.CreateCommand();
            command.CommandText = query;
            
            AddParameters(command, parameters);
            
            var result = await command.ExecuteNonQueryAsync();
            return result;

        }
        catch (Exception ex)
        {
            throw new DataBaseException("Erro para acessar os dados", ex);
        }
    }

    protected async Task<int> ExecuteUpdateAsync(string query, Dictionary<string, object>? parameters = null)
    {
        var dbConnection = await GetConnectionAsync();

        try
        {
            await using var command = dbConnection.CreateCommand();
            command.CommandText = query;
            
            AddParameters(command, parameters);
            
            var result = await command.ExecuteNonQueryAsync();
            return result;

        }
        catch (Exception ex)
        {
            throw new DataBaseException("Erro para acessar os dados", ex);
        }
    }

    private void AddParameters(SqlCommand command, Dictionary<string, object>? parameters)
    {
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
        }
    }
    
    public void Dispose()
    {
        _connection?.Dispose();
    }
}