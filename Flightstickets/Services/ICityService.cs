using Flightstickets.Models;
using System.Collections.Generic;

public interface ICityService
{
    List<City> GetAllCities();
    City GetCityById(int cityId);
    void AddCity(City city);
    void UpdateCity(City city);
    void DeleteCity(int cityId);
}
