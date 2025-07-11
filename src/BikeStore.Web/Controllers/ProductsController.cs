using BikeStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Web.Controllers
{
    public class ProductsController(IProductRepository productRepository) : Controller
    {
        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var products = await productRepository.GetAll();
            return Ok(products);
        }

    }
}
