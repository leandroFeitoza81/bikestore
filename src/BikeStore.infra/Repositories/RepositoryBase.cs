using System.Data;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Repositories;

public abstract class RepositoryBase<TModel>(SqlConnection connection)
{
    private void EnsureConnectionOpened()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }

    protected async Task<List<T>> ExecuteQueryToListAsync<T>(
        string query,
        Func<SqlDataReader, T> mapFunction,
        Dictionary<string, object> parameters = null)
    {
        EnsureConnectionOpened();
        
        var result = new List<T>();

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddRange(parameters?.Select(p => 
                                            new SqlParameter(p.Key, p.Value)).ToArray() ?? []);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(mapFunction(reader));
            }
            return result;
        }
        catch (Exception e)
        {

            throw;
        }
        
    }
}