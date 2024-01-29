using AutoMapper;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Data.Entities;

namespace OlxShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext context;
        private readonly IMapper mapper;

        public ProductsController(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private void LoadCategories()
        {
            var categories = mapper.Map<List<CategoryDto>>(context.Categories.ToList());
            ViewBag.Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
        }

        public IActionResult Index()
        {
            // get all products from the db
            var products = mapper.Map<List<ProductDto>>(context.Products.Include(x => x.Category).ToList());

            return View(products);
        }

        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto model)
        {
            // model validation
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View();
            }

            context.Products.Add(mapper.Map<Product>(model));
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            LoadCategories();
            return View(mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public IActionResult Edit(ProductDto model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View();
            }

            context.Products.Update(mapper.Map<Product>(model));
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id, string? returnUrl)
        {
            var product = context.Products.Find(id);
            if (product == null) return NotFound();

            context.Entry(product).Reference(x => x.Category).Load();

            // convert entity type to DTO
            var dto = mapper.Map<ProductDto>(product);

            ViewBag.ReturnUrl = returnUrl;
            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            context.Remove(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
