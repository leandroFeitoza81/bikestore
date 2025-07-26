using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Mappers.Interfaces;

public interface IEntityMapper<T> where T : class
{
    T Map(SqlDataReader reader);
}