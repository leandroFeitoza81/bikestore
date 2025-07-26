using BikeStore.Application.DTOs;
using BikeStore.Application.Services.Interfaces;
using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;

namespace BikeStore.Application.Services;

public class ProductServices : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductServices(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDetailDto>> GetAllProductsDetailsAsync()
    {
        var products = await _productRepository.GetAllProductAsync();

        if (products == null)
            return null;
        
        return products.Select(p => new ProductDetailDto()
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            ListPrice = p.Price,
            ModelYear = p.ModelYear,
            BrandName = p.BrandId.ToString(),
            CategoryName = p.CategoryId.ToString()
        }).ToList();
    }

    public async  Task<Product> CreateProductAsync(Product product)
    {
        var result = await _productRepository.Add(product);
        return result;    
    }
}