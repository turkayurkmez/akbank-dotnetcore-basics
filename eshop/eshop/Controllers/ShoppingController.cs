using eshop.Services;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IProductService productService;

        public ShoppingController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCard(int id)
        {
            /*
             * 1. id'si verilen ürünü bul
             * 2. bir sepet koleksiyonu oluştur.
             * 3. bu koleksiyona ürünü ekle.
             * 4. Koleksiyonu, session içinde sakla
             */

            //1. id'si verilen ürünü bul
            var product = productService.FindProduct(id);


            return Json(new { message = $"{product.Name} isimli ürün sunucuya ulaştı" });
        }
    }
}
