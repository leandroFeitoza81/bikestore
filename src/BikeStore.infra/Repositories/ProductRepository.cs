using BikeStore.Application.DTOs;
using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;
using BikeStore.Infra.Queries;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Repositories;

public class ProductRepository(string connectionString)
    : RepositoryBase<Product>(connectionString), IProductRepository
{
    public async Task<List<Product?>> GetAll()
    {
        try
        {
            var products =
                await ExecuteQueryToListAsync<Product>(ProductQueries
                    .GetProductsWithBrandAndCategoryQuery);
            
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