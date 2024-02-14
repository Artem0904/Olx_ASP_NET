using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CityService : ICityService
    {
        private readonly ShopDbContext context;
        private readonly IMapper mapper;

        public CityService(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void CreateCity(CityDto city)
        {
            var entity = mapper.Map<City>(city);
            context.Cities.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<CityDto> GetAllCities()
        {
            var cities = context.Cities.ToList();
            return mapper.Map<List<CityDto>>(cities);
        }

        public CityDto GetCityByName(string cityName)
        {
            var city = context.Cities.FirstOrDefault(c => c.Name == cityName);
            return mapper.Map<CityDto>(city);
        }
    }
}
