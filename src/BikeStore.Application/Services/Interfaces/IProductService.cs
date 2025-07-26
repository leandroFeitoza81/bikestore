using BikeStore.Application.DTOs;
using BikeStore.Domain.Entities;

namespace BikeStore.Application.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDetailDto>> GetAllProductsDetailsAsync();
    Task<Product> CreateProductAsync(Product product);
    
}