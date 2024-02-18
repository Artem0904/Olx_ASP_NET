using AutoMapper;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Data.Entities;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace OlxShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICityService cityService;
        private readonly IMapper mapper;

        public ProductsController(IProductsService productsService, ICityService cityService, IMapper mapper)
        {
            this.productsService = productsService;
            this.cityService = cityService; 
            this.mapper = mapper;
        }

        private void LoadCategories()
        {
            // Send temporary data to view
            // 1: TempData[key] = value
            // 2: ViewBag.Key = value
            var categories = productsService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            // get all products from the db
            return View(productsService.GetAll());
        }

        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            // model validation
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View();
            }

            var city = cityService.GetCityByName(model.CityName);
            if (city != null)
            {
                model.CityId = city.Id;
            }
            else
            {
                var newCityDto = new CityDto { Name = model.CityName };
                cityService.CreateCity(newCityDto);
                model.CityId = newCityDto.Id;
            }

            productsService.Create(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = productsService.Get(id);
            if (product == null) return NotFound();

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductDto model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                var errorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ViewBag.ErrorMessages = errorMessages;
                return View(model);
            }

            var city = cityService.GetCityByName(model.CityName);
            if (city != null)
            {
                model.CityId = city.Id;
            }
            else
            {
                var newCityDto = new CityDto { Name = model.CityName };
                cityService.CreateCity(newCityDto);
                model.CityId = newCityDto.Id;
            }

            productsService.Edit(model);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult Details(int id, string? returnUrl)
        {
            // get product by ID from the db
            var product = productsService.Get(id);
            if (product == null) return NotFound();

            ViewBag.ReturnUrl = returnUrl;
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            productsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
