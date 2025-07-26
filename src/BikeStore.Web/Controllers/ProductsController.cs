using BikeStore.Application.DTOs;
using BikeStore.Application.Services.Interfaces;
using BikeStore.Domain.Interfaces;
using BikeStore.Web.Extensions;
using BikeStore.Web.Mappers;
using BikeStore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Web.Controllers
{
    public class ProductsController(IProductRepository productRepository, IBrandService brandService, ICategoryService categoryService) : Controller
    {
        private readonly IBrandService _brandService = brandService;
        private readonly ICategoryService _categoryService = categoryService;
        
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            


            return RedirectToAction("Details", new {id = 1});
        }
        

    }
}
