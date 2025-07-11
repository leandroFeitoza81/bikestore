using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;

namespace BikeStore.Infrastructure.Repositories;

public class ProductRepository(string connectionString) : IProductRepository
{
    
    private readonly string _connectionString = connectionString;

    public Task<List<Product>> GetAll()
    {
        throw new NotImplementedException();
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