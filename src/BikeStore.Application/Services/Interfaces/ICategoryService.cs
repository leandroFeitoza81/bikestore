using BikeStore.Domain.Entities;

namespace BikeStore.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
}