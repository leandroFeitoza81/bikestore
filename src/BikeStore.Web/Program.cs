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

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
