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
            var newProduct = mapper.Map<Product>(product);

            if (!string.IsNullOrEmpty(product.CityName))
            {
                var city = cityService.GetCityByName(product.CityName);
                if (city == null)
                {
                    var newCityDto = new CityDto { Name = product.CityName };
                    cityService.CreateCity(newCityDto);
                    city = cityService.GetCityByName(product.CityName); 
                }
                newProduct.CityId = city.Id;
            }

            context.Products.Add(newProduct);
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
            if (!string.IsNullOrEmpty(product.CityName))
            {
                var city = cityService.GetCityByName(product.CityName);
                if (city == null)
                {
                    var newCityDto = new CityDto { Name = product.CityName };
                    cityService.CreateCity(newCityDto);
                    city = cityService.GetCityByName(product.CityName);
                }
                product.CityId = city.Id;
            }

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
