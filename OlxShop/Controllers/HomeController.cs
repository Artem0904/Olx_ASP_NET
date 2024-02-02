using Microsoft.AspNetCore.Mvc;
using DataAccess.Data;
using OlxShop.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;

namespace OlxShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            return View(productsService.GetAll());
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
