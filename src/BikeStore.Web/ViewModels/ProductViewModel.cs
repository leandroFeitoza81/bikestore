namespace BikeStore.Web.ViewModels;

public record ProductViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Price { get; set; }
    public string? BrandName { get; set; }
    public string? CategoryName { get; set; }
}