using System.Globalization;
using BikeStore.Domain.Entities;
using BikeStore.Web.ViewModels;

namespace BikeStore.Web.Mappers;

public static class ProductMapper
{
    private static ProductViewModel ToViewModel(this Product product)
    {
        return new ProductViewModel()
        {
            Id = product.ProductId,
            Name = product.ProductName,
            Price = product.Price.ToString("C", new CultureInfo("en-US")),
            BrandName = product.Brand.BrandName,
            CategoryName = product.Category.CategoryName
        };
    }
    
    public static List<ProductViewModel> ToViewModelProductList(this IEnumerable<Product> products) =>
        products.Select(ToViewModel).ToList();
    
    public static ProductViewModel ToViewModelProduct(this Product product) => product.ToViewModel();
}