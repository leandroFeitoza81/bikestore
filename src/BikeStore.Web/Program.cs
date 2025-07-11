using BikeStore.Domain.Interfaces;
using BikeStore.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository>(sp =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>()["ConnectionStrings:SqlConnection"];
    return new ProductRepository(connectionString);
});

var app = builder.Build();

app.MapControllerRoute(
    name: default,
    pattern: "{controller=Home}/{action=Index}/{id?}"
    )
    .WithStaticAssets();

app.Run();
