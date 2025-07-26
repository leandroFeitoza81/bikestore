using BikeStore.Domain.Entities;

namespace BikeStore.Domain.Interfaces;

public interface IBrandRepository
{
    Task<List<Brand?>> GetAll();
}