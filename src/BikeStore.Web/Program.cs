using BikeStore.Application.Services;
using BikeStore.Application.Services.Interfaces;
using BikeStore.Domain.Interfaces;
using BikeStore.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IProductRepository>(sp =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>()["ConnectionStrings:SqlConnection"];
    return new ProductRepository(connectionString);   
});
    
builder.Services.AddScoped<ICategoryRepository>(sp =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>()["ConnectionStrings:SqlConnection"];
    return new CategoryRepository(connectionString);
});
builder.Services.AddScoped<IBrandRepository>(sp =>
{
    var connectionString = sp.GetRequiredService<IConfiguration>()["ConnectionStrings:SqlConnection"];
    return new BrandRepository(connectionString);
});

builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
