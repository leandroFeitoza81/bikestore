using BikeStore.Domain.Entities;

namespace BikeStore.Domain.Interfaces;

public interface IProductRepository
{
    Task<List<Product?>> GetAllProductAsync();
    Task<Product?> GetById(int id);
    Task<Product> Add(Product product);
    Task<int> Update(Product product);
    Task<int> Delete(Product product);
}
