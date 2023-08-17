using eshop.Models;
using eshop.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eshop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? gidilecekSayfa)
        {
            ViewBag.ReturnUrl = gidilecekSayfa;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string? gidilecekSayfa)
        {
            /*
             * 1. model uygunsa
             * 2. kullanıcı adı ve şifreyi kullanarak kullanıcıyı doğrula
             * 3. Doğrulanan kullanıcının claim bilgilerini al.
             * 4. oturum açtı bilgisini kaydet
             * 5. gidilecek sayfaya yönlendir
             */

            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims = new[]
                    {
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim(ClaimTypes.Role,user.Role),
                        new Claim(ClaimTypes.Email,user.Email)

                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                    {
                        return Redirect(gidilecekSayfa);
                    }
                    //return Redirect("/");
                    return RedirectToAction(actionName: "Index", controllerName: "Home");

                }
                ModelState.AddModelError("login", "Kullanıcı adı veya şifre yanlış");
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
