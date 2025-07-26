using BikeStore.Domain.Entities;
using BikeStore.Domain.Interfaces;
using BikeStore.Infra.Mappers;
using BikeStore.Infra.Queries;

namespace BikeStore.Infra.Repositories;

public class BrandRepository(string connectionString)
    : RepositoryBase(connectionString), IBrandRepository
{
    
    private readonly BrandMapper _brandMapper = new();
    
    public async Task<List<Brand?>> GetAll()
    {
        try
        {
            var brands = await ExecuteQueryToListAsync<Brand>(BrandQueries.GetAllBrands, _brandMapper);
            
            return brands;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
}