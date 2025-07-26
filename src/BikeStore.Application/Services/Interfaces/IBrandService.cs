using BikeStore.Domain.Entities;

namespace BikeStore.Application.Services.Interfaces;

public interface IBrandService
{
    Task<List<Brand>> GetAllBrandsAsync();
}