using eshop.Models;
using eshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            //Product nesnesi, kurallara uygun mu?
            //Uygunsa ekle
            //Değilse hata bildir. 
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = productService.FindProduct(id);
            return View(product);
        }
    }
}
