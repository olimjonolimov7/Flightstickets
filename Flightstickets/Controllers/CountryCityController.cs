using Flightstickets.Models;
using Flightstickets.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]/[action]")]
public class CountryCityController : ControllerBase
{
    private readonly ICountryCityService _countryCityService;

    public CountryCityController(ICountryCityService countryCityService)
    {
        _countryCityService = countryCityService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CountryCity>> GetAllCountryCities()
    {
        try
        {
            var countryCities = _countryCityService.GetAllCountryCities();
            return Ok(countryCities);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{countryCityId}")]
    public ActionResult<CountryCity> GetCountryCityById(int countryCityId)
    {
        try
        {
            var countryCity = _countryCityService.GetCountryCityById(countryCityId);
            if (countryCity == null)
                return NotFound();

            return Ok(countryCity);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<CountryCity> AddCountryCity([FromBody] CountryCity countryCity)
    {
        try
        {
            _countryCityService.AddCountryCity(countryCity);
            return CreatedAtAction(nameof(GetCountryCityById), new { countryCityId = countryCity.CountryCityId }, countryCity);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{countryCityId}")]
    public IActionResult UpdateCountryCity(int countryCityId, [FromBody] CountryCity countryCity)
    {
        try
        {
            var existingCountryCity = _countryCityService.GetCountryCityById(countryCityId);
            if (existingCountryCity == null)
                return NotFound();

            countryCity.CountryCityId = countryCityId;
            _countryCityService.UpdateCountryCity(countryCity);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{countryCityId}")]
    public IActionResult DeleteCountryCity(int countryCityId)
    {
        try
        {
            var existingCountryCity = _countryCityService.GetCountryCityById(countryCityId);
            if (existingCountryCity == null)
                return NotFound();

            _countryCityService.DeleteCountryCity(countryCityId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
