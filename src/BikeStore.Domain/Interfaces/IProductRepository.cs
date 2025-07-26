using BikeStore.Domain.Entities;

namespace BikeStore.Domain.Interfaces;

public interface IProductRepository
{
    Task<List<Product?>> GetAllProductAsync();
    Task<Product?> GetById(int id);
    Task<bool> Add(Product product);
    Task<bool> Update(Product product);
    Task<int> Delete(Product product);
}
