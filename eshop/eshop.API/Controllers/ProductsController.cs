using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.FindProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
