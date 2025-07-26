using BikeStore.Application.DTOs;
using BikeStore.Domain.Entities;

namespace BikeStore.Application.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDetailDto>> GetAllProductsDetailsAsync();
    Task<bool> CreateProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(int id);
    Task<bool> UpdateProductAsync(Product product);
    
}