using System.Globalization;
using BikeStore.Domain.Entities;
using BikeStore.Web.ViewModels;

namespace BikeStore.Web.Mappers;

public static class ProductMapper
{
    private static ProductViewModel ToViewModel(Product product)
    {
        return new ProductViewModel()
        {
            Id = product.ProductId,
            Name = product.ProductName,
            Price = product.Price.ToString("C", new CultureInfo("pt-Br")),
            BrandName = product.BrandId.ToString(),
            CategoryName = product.CategoryId.ToString()
        };
    }
    
    public static List<ProductViewModel> ToViewModelList(IEnumerable<Product> products) =>
        products.Select(ToViewModel).ToList();
}