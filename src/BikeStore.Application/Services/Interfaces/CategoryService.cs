using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;

namespace BikeStore.Application.Services.Interfaces;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<List<Category>> GetAllCategoriesAsync()
    {
        return _categoryRepository.GetAll();
    }
}