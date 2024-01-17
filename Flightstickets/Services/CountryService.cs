using Flightstickets.Models;
using Flightstickets.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flightstickets.Services;
    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Country> GetAllCountries()
        {
            return _dbContext.Countries.ToList();
        }

        public Country GetCountryById(int countryId)
        {
            return _dbContext.Countries.Find(countryId);
        }

        public void AddCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _dbContext.Countries.Update(country);
            _dbContext.SaveChanges();
        }

        public void DeleteCountry(int countryId)
        {
            var country = _dbContext.Countries.Find(countryId);
            if (country != null)
            {
                _dbContext.Countries.Remove(country);
                _dbContext.SaveChanges();
            }
        }
    }
