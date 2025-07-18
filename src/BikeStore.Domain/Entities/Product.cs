namespace BikeStore.Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
}