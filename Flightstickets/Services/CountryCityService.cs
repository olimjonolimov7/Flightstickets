using Flightstickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flightstickets.Services;
    public class CountryCityService : ICountryCityService
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryCityService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CountryCity> GetAllCountryCities()
        {
            return _dbContext.CountryCities.ToList();
        }

        public CountryCity GetCountryCityById(int countryCityId)
        {
            return _dbContext.CountryCities.Find(countryCityId);
        }

        public void AddCountryCity(CountryCity countryCity)
        {
            _dbContext.CountryCities.Add(countryCity);
            _dbContext.SaveChanges();
        }

        public void UpdateCountryCity(CountryCity countryCity)
        {
            _dbContext.CountryCities.Update(countryCity);
            _dbContext.SaveChanges();
        }

        public void DeleteCountryCity(int countryCityId)
        {
            var countryCity = _dbContext.CountryCities.Find(countryCityId);
            if (countryCity != null)
            {
                _dbContext.CountryCities.Remove(countryCity);
                _dbContext.SaveChanges();
            }
        }
    }
