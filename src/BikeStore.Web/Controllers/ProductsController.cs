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
            var viewModels = ProductMapper.ToViewModelList(products);
            
            return View(viewModels);
        }

    }
}
