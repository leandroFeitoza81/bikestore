using BikeStore.Domain.Interfaces;
using BikeStore.Web.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Web.Controllers
{
    public class ProductsController(IProductRepository productRepository) : Controller
    {
        public async Task<ActionResult> Index()
        {
            var products = await productRepository.GetAll();
            var viewModels = products.ToViewModelProductList();
            
            return View(viewModels);
        }

        public async Task<ActionResult> Details(int id)
        {
            var product = await productRepository.GetById(id);
            
            var viewModel = product.ToViewModelProduct();
            
            return View(viewModel);
        }

    }
}
