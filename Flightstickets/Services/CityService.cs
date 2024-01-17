
using Flightstickets.Models;
using System.Collections.Generic;
using System.Linq;
namespace Flightstickets.Services;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _dbContext;

        public CityService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<City> GetAllCities()
        {
            return _dbContext.Cities.ToList();
        }

        public City GetCityById(int cityId)
        {
            return _dbContext.Cities.Find(cityId);
        }

        public void AddCity(City city)
        {
            _dbContext.Cities.Add(city);
            _dbContext.SaveChanges();
        }

        public void UpdateCity(City city)
        {
            _dbContext.Cities.Update(city);
            _dbContext.SaveChanges();
        }

        public void DeleteCity(int cityId)
        {
            var city = _dbContext.Cities.Find(cityId);
            if (city != null)
            {
                _dbContext.Cities.Remove(city);
                _dbContext.SaveChanges();
            }
        }
    }

