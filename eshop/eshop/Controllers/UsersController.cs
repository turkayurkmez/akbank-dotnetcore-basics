using eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? gidilecekSayfa)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel userLogin, string gidilecekSayfa)
        {
            /*
             * 1. model uygunsa
             * 2. kullanıcı adı ve şifreyi kullanara kullanıcıyı doğrula
             * 3. Doğrulanan kullanıcının claim bilgilerini al.
             * 4. oturum açtı bilgisini kaydet
             * 5. gidilecek sayfaya yönlendir
             */

        }
    }
}
