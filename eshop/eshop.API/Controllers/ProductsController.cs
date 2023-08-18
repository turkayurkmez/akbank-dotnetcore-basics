using eshop.Application.Services;
using eshop.Infrastructure.Entities;
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
        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var products = await _productService.SearchByName(name);
            return Ok(products);
        }

        //REST API: 
        //Representational State Transfer
        //Cookie -> Authentication
        //Session -> Sepet
        [HttpPost]
        public IActionResult CreateNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = product.Id }, value: null);
            }

            return BadRequest(ModelState);
        }


    }
}
