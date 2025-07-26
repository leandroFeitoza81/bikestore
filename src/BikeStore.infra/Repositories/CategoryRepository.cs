using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;
using BikeStore.Infra.Mappers;
using BikeStore.Infra.Queries;

namespace BikeStore.Infra.Repositories;

public class CategoryRepository(string connectionString)
    : RepositoryBase(connectionString), ICategoryRepository
{
    private readonly CategoryMapper _categoryMapper = new();
    
    public async Task<List<Category?>> GetAll()
    {
        var categories = await ExecuteQueryToListAsync<Category>(CategoryQueries.GetAllCategories, _categoryMapper);
        return categories;
    }
}