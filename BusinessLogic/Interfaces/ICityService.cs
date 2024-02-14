using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICityService
    {
        IEnumerable<CityDto> GetAllCities();
        void CreateCity(CityDto city);
        CityDto GetCityByName(string cityName);
        //IEnumerable<CountryDto> GetAllCountries();
    }
}
