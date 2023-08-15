using eshop.Models;
using eshop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductService productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(int pageNo = 1, int? category = null)
        {
            //var productService = 
            var products = category == null ? productService.GetProducts()
                                            : productService.GetProductsByCategoryId(category.Value);

            ViewBag.Category = category;

            var pageSize = 4;
            var totalPages = (int)Math.Ceiling((decimal)products.Count / pageSize);


            ViewBag.Pages = totalPages;

            /*
             * 1. sayfada 0 atla 4 al
             * 2. sayfada 4 atla 4 al
             * 3. sayfada 8 atla 4 al
             */
            var paginated = products.OrderBy(p => p.Id)
                                    .Skip((pageNo - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();


            return View(paginated);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}