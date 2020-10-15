using Microsoft.AspNetCore.Mvc;
using Skaitykla.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skaitykla.MVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]      //per sita formos metoda tiktai prieisim
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AuthError = "Blogi prisijungimo duomenys";
                return View("~/Views/Auth/Index.cshtml");
            }


            return View();
        }
    }
}
