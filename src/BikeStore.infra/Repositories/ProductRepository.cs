using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Repositories;

public class ProductRepository(string connectionString) : IProductRepository
{
    public async Task<List<Product>> GetAll()
    {
        try
        {
            var products = new List<Product>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("select * from BikeStores.production.products p ", conn);
                var reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    products.Add(new Product()
                    {
                        ProductId = reader["list_price"] is DBNull ? 0 : Convert.ToInt32(reader["product_id"]),
                        ProductName = reader["product_name"] is DBNull ? string.Empty : reader["product_name"].ToString(),
                        Price = reader["list_price"] is DBNull ? 0 : Convert.ToDecimal(reader["list_price"]),
                        BrandId = reader["brand_id"] is DBNull ? 0 : Convert.ToInt32(reader["brand_id"]),
                        CategoryId = reader["category_id"] is DBNull ? 0 : Convert.ToInt32(reader["category_id"]),
                    });
                }
            }
        
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
      
    }

    public Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Product product)
    {
        throw new NotImplementedException();
    }

    public Task Update(Product product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Product product)
    {
        throw new NotImplementedException();
    }
}