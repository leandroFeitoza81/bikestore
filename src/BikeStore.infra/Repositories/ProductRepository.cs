using BikeStore.Application.DTOs;
using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;
using BikeStore.Infra.Extensions;
using BikeStore.Infra.Mappers;
using BikeStore.Infra.Queries;
using Microsoft.Data.SqlClient;

namespace BikeStore.Infra.Repositories;

public class ProductRepository(string connectionString) : RepositoryBase(connectionString), IProductRepository
{
    private readonly ProductMapper _productMapper = new();
    private readonly BrandMapper _brandMapper = new();

    public async Task<List<Product?>> GetAllProductAsync()
    {
        var result = await ExecuteQueryToListAsync(
            ProductQueries.GetProductsWithBrandAndCategoryQuery, _productMapper);
        return result;
    }

    public async Task<Product?> GetById(int id)
    {
        var parameterId = new Dictionary<string, object>
        {
            { "@ProductId", id }
        };

        return await ExecuteQueryFirstOrDefaultAsync(
            ProductQueries.GetProductByIdQuery, _productMapper, parameterId);
    }

    public async Task<bool> Add(Product product)
    {
        var parameter = new Dictionary<string, object>
        {
            { "@ProductName", product.ProductName },
            { "@Price", product.Price },
            { "@ModelYear", product.ModelYear },
            { "@BrandId", product.BrandId },
            { "@CategoryId", product.CategoryId }
        };
        
        var result = await ExecuteInsertAsync(
            ProductQueries.AddProductQuery, parameter);

        return result > 0;
    }

    public async Task<bool> Update(Product product)
    {
        var parameter = new Dictionary<string, object>
        {
            { "@ProductId", product.ProductId },
            { "@ProductName", product.ProductName },
            { "@Price", product.Price },
            { "@ModelYear", product.ModelYear },
            { "@BrandId", product.BrandId },
            { "@CategoryId", product.CategoryId }
        };

        var result = await ExecuteUpdateAsync(
            ProductQueries.AddProductQuery, parameter);
        
        return result > 0;
    }

    public Task<int> Delete(Product product)
    {
        throw new NotImplementedException();
    }

    // public async Task<int> Delete(Product product)
    // {
    //     var parameter = new Dictionary<string, object>
    //     {
    //         { "@ProductId", product.ProductId }
    //     };
    //     
    //     return await ExecuteUpdateAsync(
    //         )
    // }
    
}