using BikeStore.Application.Services.Interfaces;
using BikeStore.Domain.Entities;
using BikeStore.Web.ViewModels;
using BikeStore.Web.ViewModels.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeStore.Web.Extensions;

public static class ProductViewModelExtensions
{
    
    public static async Task PopulateDropdownAsync<T>(this T viewModel,
        IBrandService brandService, ICategoryService categoryService) where T : ProductFormViewModel
    {
        var brands = await brandService.GetAllBrandsAsync();
        var categories = await categoryService.GetAllCategoriesAsync();
        
        viewModel.Brands = brands.Select(b => new SelectListItem()
        {
            Value = b.BrandId.ToString(),
            Text = b.BrandName
        }).ToList();
        
        viewModel.Categories = categories.Select(c => new SelectListItem()
        {
            Value = c.CategoryId.ToString(),
            Text = c.CategoryName
        }).ToList();
    }
    
    public static Product ToEntity(this CreateProductViewModel viewModel)
    {
        return new Product()
        {
            ProductName = viewModel.ProductName?.Trim(),
            Price = viewModel.ListPrice,
            BrandId = viewModel.BrandId,
            CategoryId = viewModel.CategoryId,
            ModelYear = viewModel.ModelYear
        };
    }

    public static Product ToEntity(this EditProductViewModel viewModel)
    {
        return new Product()
        {
            ProductId = viewModel.Id,
            ProductName = viewModel.ProductName?.Trim(),
            Price = viewModel.ListPrice,
            BrandId = viewModel.BrandId,
            CategoryId = viewModel.CategoryId,
            ModelYear = viewModel.ModelYear
        };
    }

    public static EditProductViewModel ToEditViewModel(this Product product)
    {
        return new EditProductViewModel()
        {
            Id = product.ProductId,
            ProductName = product.ProductName,
            ListPrice = product.Price,
            BrandId = product.BrandId,
            CategoryId = product.CategoryId,
            ModelYear = product.ModelYear
        };
    }
}