using Flightstickets.Models;
using Flightstickets.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]/[action]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Country>> GetAllCountries()
    {
        try
        {
            var countries = _countryService.GetAllCountries();
            return Ok(countries);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{countryId}")]
    public ActionResult<Country> GetCountryById(int countryId)
    {
        try
        {
            var country = _countryService.GetCountryById(countryId);
            if (country == null)
                return NotFound();

            return Ok(country);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Country> AddCountry([FromBody] Country country)
    {
        try
        {
            _countryService.AddCountry(country);
            return CreatedAtAction(nameof(GetCountryById), new { countryId = country.CountryId }, country);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{countryId}")]
    public IActionResult UpdateCountry(int countryId, [FromBody] Country country)
    {
        try
        {
            var existingCountry = _countryService.GetCountryById(countryId);
            if (existingCountry == null)
                return NotFound();

            country.CountryId = countryId;
            _countryService.UpdateCountry(country);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{countryId}")]
    public IActionResult DeleteCountry(int countryId)
    {
        try
        {
            var existingCountry = _countryService.GetCountryById(countryId);
            if (existingCountry == null)
                return NotFound();

            _countryService.DeleteCountry(countryId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
