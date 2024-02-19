using AutoMapper;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Data.Entities;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Humanizer;
using System;

namespace OlxShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICityService cityService;
        private readonly IMapper mapper;
        private readonly UserManager<User> UserManager;
        private readonly IUsersService usersService;


        public ProductsController(IProductsService productsService, ICityService cityService, IMapper mapper, UserManager<User> UserManager, IUsersService usersService)
        {
            this.productsService = productsService;
            this.cityService = cityService; 
            this.mapper = mapper;
            this.UserManager = UserManager;
            this.usersService = usersService;
        }
        private async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.GetUserAsync(User);
            return user;
            
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

        public IActionResult Create(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
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

            var user = GetCurrentUserAsync();
            model.UserId = user.Result.Id;
            model.UserName = user.Result.UserName;


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

            var user = usersService.Get(product.UserId);

            ViewBag.user = user;
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
