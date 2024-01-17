using Flightstickets.Models;
using Flightstickets.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]/[action]")]
public class FlightController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Flight>> GetAllFlights()
    {
        try
        {
            var flights = _flightService.GetAllFlights();
            return Ok(flights);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{flightId}")]
    public ActionResult<Flight> GetFlightById(int flightId)
    {
        try
        {
            var flight = _flightService.GetFlightById(flightId);
            if (flight == null)
                return NotFound();

            return Ok(flight);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Flight> AddFlight([FromBody] Flight flight)
    {
        try
        {
            _flightService.AddFlight(flight);
            return CreatedAtAction(nameof(GetFlightById), new { flightId = flight.FlightId }, flight);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{flightId}")]
    public IActionResult UpdateFlight(int flightId, [FromBody] Flight flight)
    {
        try
        {
            var existingFlight = _flightService.GetFlightById(flightId);
            if (existingFlight == null)
                return NotFound();

            flight.FlightId = flightId;
            _flightService.UpdateFlight(flight);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{flightId}")]
    public IActionResult DeleteFlight(int flightId)
    {
        try
        {
            var existingFlight = _flightService.GetFlightById(flightId);
            if (existingFlight == null)
                return NotFound();

            _flightService.DeleteFlight(flightId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
