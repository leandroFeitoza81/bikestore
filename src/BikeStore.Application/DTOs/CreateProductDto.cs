namespace BikeStore.Application.DTOs;

public class CreateProductDto
{
    public string? ProductName { get; set; } = string.Empty;
    public decimal ListPrice { get; set; }
    public int ModelYear { get; set; }
    public string? BrandName { get; set; } = string.Empty;
    public string? CategoryName { get; set; } = string.Empty;
}