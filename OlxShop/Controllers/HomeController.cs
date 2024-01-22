using Microsoft.AspNetCore.Mvc;
using OlxShop.Data;
using OlxShop.Models;
using System.Diagnostics;

namespace OlxShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
         
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            // logic: get/save/validate data

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
