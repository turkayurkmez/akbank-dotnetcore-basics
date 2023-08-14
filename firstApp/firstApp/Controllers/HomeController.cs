using firstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserName = "Türkay";
            ViewBag.Hour = DateTime.Now.Hour;

            //dynamic value = 9;
            //value.
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View();
        }


    }
}
