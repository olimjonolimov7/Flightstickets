using Flightstickets.Models;
using System.Collections.Generic;

public interface ICountryCityService
{
    List<CountryCity> GetAllCountryCities();
    CountryCity GetCountryCityById(int countryCityId);
    void AddCountryCity(CountryCity countryCity);
    void UpdateCountryCity(CountryCity countryCity);
    void DeleteCountryCity(int countryCityId);
}
