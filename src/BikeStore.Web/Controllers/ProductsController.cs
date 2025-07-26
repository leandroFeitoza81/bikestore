using BikeStore.Application.DTOs;
using BikeStore.Application.Services.Interfaces;
using BikeStore.Domain.Interfaces;
using BikeStore.Web.Extensions;
using BikeStore.Web.Mappers;
using BikeStore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Web.Controllers
{
    public class ProductsController(
        IProductRepository productRepository,
        IBrandService brandService, 
        ICategoryService categoryService,
        IProductService productService) : Controller
    {
        private readonly IBrandService _brandService = brandService;
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;
        
        public async Task<ActionResult> Index()
        {
            var products = await productRepository.GetAllProductAsync();
            var viewModels = products.ToViewModelProductList();
            
            return View(viewModels);
        }

        public async Task<ActionResult> Details(int id)
        {
            var product = await productRepository.GetById(id);
            
            var viewModel = product.ToViewModelProduct();
            
            return View(viewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateProductViewModel();
            await viewModel.PopulateDropdownAsync(_brandService, _categoryService);
            
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(createProductViewModel);
                
                var product = createProductViewModel.ToEntity();
                var createdProduct = await productRepository.Add(product);
                
                if (!createdProduct)
                    return View(createProductViewModel);
                
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            var viewModel = product.ToEditViewModel();
            await viewModel.PopulateDropdownAsync(_brandService, _categoryService);
            
            return View(viewModel);
            
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await viewModel.PopulateDropdownAsync(_brandService, _categoryService);
                    return View(viewModel);
                }

                var product = viewModel.ToEntity();
                var result = await _productService.UpdateProductAsync(product);
                
                if (!result)
                    return View(viewModel);
                
                TempData["message"] = "Product updated successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao atualizar o produto.");
                await viewModel.PopulateDropdownAsync(_brandService, _categoryService);
                return View(viewModel);
            }
        }


    }
}
