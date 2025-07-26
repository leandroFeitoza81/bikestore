using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Extensions;

public static class SqlCommandExtensions
{
    public static void AddParametersWithValue(this SqlCommand command, string parameterName, object value)
    {
        command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
    }
}