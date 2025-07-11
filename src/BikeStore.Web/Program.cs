using BikeStore.Domain.Interfaces;
using BikeStore.Infrastructure.Repositories;

namespace BikeStore.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IProductRepository>(sp =>
        {
            var connectionString = sp.GetRequiredService<IConfiguration>()["ConnectionStrings:SqlConnection"];
            return new ProductRepository(connectionString ?? string.Empty);
        });
        
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}