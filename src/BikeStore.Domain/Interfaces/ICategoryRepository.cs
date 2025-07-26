using BikeStore.Domain.Entities;

namespace BikeStore.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category?>> GetAll();
}