using BikeStore.Domain.Entities;
using BikeStore.Infra.Mappers.Interfaces;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Mappers;

public class BrandMapper : IEntityMapper<Brand>
{
    public Brand Map(SqlDataReader reader)
    {
        return new Brand()
        {
            BrandId = reader["BrandId"] is DBNull ? 0 : (int)reader["BrandId"],
            BrandName = reader["BrandName"] is DBNull ? string.Empty : reader["BrandName"].ToString()
        };
    }
}