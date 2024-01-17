using Flightstickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]/[action]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<City>> GetAllCities()
    {
        try
        {
            var cities = _cityService.GetAllCities();
            return Ok(cities);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{cityId}")]
    public ActionResult<City> GetCityById(int cityId)
    {
        try
        {
            var city = _cityService.GetCityById(cityId);
            if (city == null)
                return NotFound();

            return Ok(city);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<City> AddCity([FromBody] City city)
    {
        try
        {
            _cityService.AddCity(city);
            return CreatedAtAction(nameof(GetCityById), new { cityId = city.CityId }, city);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{cityId}")]
    public IActionResult UpdateCity(int cityId, [FromBody] City city)
    {
        try
        {
            var existingCity = _cityService.GetCityById(cityId);
            if (existingCity == null)
                return NotFound();

            city.CityId = cityId;
            _cityService.UpdateCity(city);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{cityId}")]
    public IActionResult DeleteCity(int cityId)
    {
        try
        {
            var existingCity = _cityService.GetCityById(cityId);
            if (existingCity == null)
                return NotFound();

            _cityService.DeleteCity(cityId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
