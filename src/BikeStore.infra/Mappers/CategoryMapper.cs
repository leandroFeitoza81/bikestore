using BikeStore.Domain.Entities;
using BikeStore.Infra.Mappers.Interfaces;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Mappers;

public class CategoryMapper : IEntityMapper<Category>
{
    public Category Map(SqlDataReader reader)
    {
        return new Category()
        {
            CategoryId = reader["CategoryId"] is DBNull ? 0 : (int)reader["CategoryId"],
            CategoryName = reader["CategoryName"] is DBNull ? string.Empty : reader["CategoryName"].ToString()
        };
    }
}