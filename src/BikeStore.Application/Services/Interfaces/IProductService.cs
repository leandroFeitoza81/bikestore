using BikeStore.Application.DTOs;

namespace BikeStore.Application.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDetailDto>> GetAllProductsDetailsAsync();
}