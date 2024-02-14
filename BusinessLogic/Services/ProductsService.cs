using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper mapper;
        private readonly ShopDbContext context;

        private readonly ICityService cityService;

        public ProductsService(IMapper mapper, ShopDbContext context, ICityService cityService)
        {
            this.mapper = mapper;
            this.context = context;
            this.cityService = cityService;
        }

        public void Create(ProductDto product)
        {
            var entity = mapper.Map<Product>(product);

            // If the city name is provided, try to get the city from the database or create a new one
            if (!string.IsNullOrEmpty(product.CityName))
            {
                var city = cityService.GetCityByName(product.CityName);
                if (city == null)
                {
                    // If the city doesn't exist, create a new one
                    var newCityDto = new CityDto { Name = product.CityName };
                    cityService.CreateCity(newCityDto);
                    city = cityService.GetCityByName(product.CityName); // Retrieve the newly created city
                }
                entity.CityId = city.Id; // Set the city Id for the product entity
            }

            context.Products.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            // delete product by id
            var product = context.Products.Find(id);

            if (product == null) return; // TODO: throw exception

            context.Remove(product);
            context.SaveChanges();
        }

        public void Edit(ProductDto product)
        {
            context.Products.Update(mapper.Map<Product>(product));
            context.SaveChanges();
        }

        public ProductDto? Get(int id)
        {
            var item = context.Products.Find(id);
            if (item == null) return null;

            // load related entity
            context.Entry(item).Reference(x => x.Category).Load();

            // convert entity type to DTO
            // 2 - using AutoMapper
            var dto = mapper.Map<ProductDto>(item);

            return dto;
        }

        public IEnumerable<ProductDto> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<ProductDto>>(context.Products
                .Include(x => x.Category)
                .Include(x => x.City)
                //.Include(x => x.City.Country)
                .Where(x => ids.Contains(x.Id))
                .ToList());
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return mapper.Map<List<ProductDto>>(context.Products.Include(x => x.Category).Include(x => x.City)/*.Include(x => x.City.Country)*/.ToList());
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return mapper.Map<List<CategoryDto>>(context.Categories.ToList());
        }
    }
}
