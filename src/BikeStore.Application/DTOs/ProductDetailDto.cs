using System.Data;

namespace BikeStore.Application.DTOs;

public class ProductDetailDto 
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; } = string.Empty;
    public decimal ListPrice { get; set; }
    public int ModelYear { get; set; }
    public string? BrandName { get; set; } = string.Empty;
    public string? CategoryName { get; set; } = string.Empty;
    
    // public ProductDetailDto MapFromDataReader(IDataReader reader) =>
    //  new ProductDetailDto()
    //  {
    //      ProductId = reader["product_id"] is DBNull ? 0 : Convert.ToInt32(reader["product_id"]),
    //      ProductName = reader["product_name"] is DBNull ? string.Empty : reader["product_name"].ToString(),
    //      ListPrice = reader["list_price"] is DBNull ? 0 : Convert.ToDecimal(reader["list_price"]),
    //      ModelYear = reader["model_year"] is DBNull ? 0 : Convert.ToInt16(reader["model_year"]),
    //      BrandName = reader["brand_name"] is DBNull ? string.Empty : reader["brand_name"].ToString(),
    //      Category = reader["category_name"] is DBNull ? string.Empty : reader["category_name"].ToString()
    //  };
}