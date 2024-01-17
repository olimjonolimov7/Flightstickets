using Flightstickets.Models;
using System.Collections.Generic;

public interface ICountryService
{
    List<Country> GetAllCountries();
    Country GetCountryById(int countryId);
    void AddCountry(Country country);
    void UpdateCountry(Country country);
    void DeleteCountry(int countryId);
}
