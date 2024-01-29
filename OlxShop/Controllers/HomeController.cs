using Microsoft.AspNetCore.Mvc;
using DataAccess.Data;
using OlxShop.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace OlxShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopDbContext context;
        public HomeController(ShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var products = context.Products.Include(x => x.Category).ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
