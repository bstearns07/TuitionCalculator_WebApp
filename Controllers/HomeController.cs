using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TuitionCalculator_WebApp.Models;

namespace TuitionCalculator_WebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CollegeCost model)
        {
            return View(model);
        }
    }
}
