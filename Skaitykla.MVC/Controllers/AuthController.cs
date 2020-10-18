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
            var People = new List<Person>()
            {
                new Person("Igne", "Valioniene", "igne@email.com", "password"),
                new Person("Amadeus", "Valionis", "amadeus@email.com", "password"),
                new Person("Vardenis", "Pavardenis", "vardenis@email.com", "password2")
            };
            

            if (!ModelState.IsValid)
            {
                ViewBag.AuthError = "Nepilni prisijungimo duomenys";
                return View("~/Views/Auth/Index.cshtml");
            }
            else
            {
                if(People.Any(Person => Person.Email == model.Email && Person.Password == model.Password))
                {
                    return View("~/Views/Auth/LoggedIn.cshtml");
                }
                else if (People.Any(Person => Person.Email != model.Email || Person.Password != model.Password))
                {
                    ViewBag.AuthError = "Blogas email arba password";
                    return View("~/Views/Auth/Index.cshtml");
                }
                //foreach (var person in People)
                //{
                //    if(person.Email==model.Email && person.Password == model.Password)
                //    {
                //        return View("~/Views/Auth/LoggedIn.cshtml");
                //    }else if (person.Email != model.Email || person.Password != model.Password)
                //    {
                //        ViewBag.AuthError = "Blogas email arba password";
                //        return View("~/Views/Auth/Index.cshtml");
                //    }
                //}
            }

            return View();
        }
    }
}
