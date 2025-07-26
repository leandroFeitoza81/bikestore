using BikeStore.Application.Services.Interfaces;
using BikeStore.Domain.Entities;
using BikeStore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeStore.Web.Extensions;

public static class ViewModelExtensions
{
    public static Product ToEntity(this CreateProductViewModel viewModel)
    {
        return new Product()
        {
            ProductName = viewModel.ProductName?.Trim(),
            Price = viewModel.ListPrice,
            ModelYear = viewModel.ModelYear,
            BrandId = viewModel.BrandId,
            CategoryId = viewModel.CategoryId
        };
    }

    public static async Task PopulateDropdownAsync(this CreateProductViewModel viewModel,
        IBrandService brandService, ICategoryService categoryService)
    {
        var brands = await brandService.GetAllBrandsAsync();
        var categories = await categoryService.GetAllCategoriesAsync();
        
        viewModel.Brands = brands.Select(b => new SelectListItem()
        {
            Value = b.BrandId.ToString(),
            Text = b.BrandName.ToString()
        }).ToList();
        
        viewModel.Categories = categories.Select(c => new SelectListItem()
        {
            Value = c.CategoryId.ToString(),
            Text = c.CategoryName.ToString()
        }).ToList();
    }
}