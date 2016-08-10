using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcLibrary.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Minimalist web application to apply ASP.NET MVC and Entity Framework learning.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Giulianno Sbrugnera";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
