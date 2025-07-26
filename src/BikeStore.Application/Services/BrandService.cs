using BikeStore.Application.Services.Interfaces;
using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;

namespace BikeStore.Application.Services;

public class BrandService(IBrandRepository brandRepository) : IBrandService
{
    public async Task<List<Brand>> GetAllBrandsAsync()
    {
        var brands = await brandRepository.GetAll();
        return brands;
    }
}