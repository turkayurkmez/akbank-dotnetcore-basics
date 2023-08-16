using eshop.Models;
using eshop.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            //2. bir sepet koleksiyonu oluştur.
            ShoppingCollection shoppingCollection = getCollectionFromSession();
            ProductItem productItem = new ProductItem { Product = product, Quantity = 1 };
            // 3. bu koleksiyona ürünü ekle.
            shoppingCollection.Add(productItem);
            //4.Koleksiyonu, session içinde sakla
            saveCollectionToSession(shoppingCollection);



            return Json(new { message = $"{product.Name} isimli ürün sunucuya ulaştı" });
        }

        private void saveCollectionToSession(ShoppingCollection shoppingCollection)
        {
            var serializedToJson = JsonConvert.SerializeObject(shoppingCollection);
            HttpContext.Session.SetString("sepet", serializedToJson);
        }

        private ShoppingCollection getCollectionFromSession()
        {
            //İlk kez bir koleksiyon oluşuyorsa instance döndür; daha önce koleksiyon oluşmuş ise var olanı döndür.
            string json = HttpContext.Session.GetString("sepet");
            if (!string.IsNullOrEmpty(json))
            {
                var collection = JsonConvert.DeserializeObject<ShoppingCollection>(json);
                return collection;
            }

            return new ShoppingCollection();

        }
    }
}
