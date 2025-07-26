using BikeStore.Domain.Entities;
using BikeStore.Infra.Mappers.Interfaces;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Mappers;

public class ProductMapper : IEntityMapper<Product>
{
    public Product Map(SqlDataReader reader)
    {
        return new Product()
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
        
    }
}