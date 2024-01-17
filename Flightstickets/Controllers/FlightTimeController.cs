using Flightstickets.Models;
using Flightstickets.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]/[action]")]
public class FlightTimeController : ControllerBase
{
    private readonly IFlightTimeService _flightTimeService;

    public FlightTimeController(IFlightTimeService flightTimeService)
    {
        _flightTimeService = flightTimeService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FlightTime>> GetAllFlightTimes()
    {
        try
        {
            var flightTimes = _flightTimeService.GetAllFlightTimes();
            return Ok(flightTimes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{flightTimeId}")]
    public ActionResult<FlightTime> GetFlightTimeById(int flightTimeId)
    {
        try
        {
            var flightTime = _flightTimeService.GetFlightTimeById(flightTimeId);
            if (flightTime == null)
                return NotFound();

            return Ok(flightTime);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<FlightTime> AddFlightTime([FromBody] FlightTime flightTime)
    {
        try
        {
            _flightTimeService.AddFlightTime(flightTime);
            return CreatedAtAction(nameof(GetFlightTimeById), new { flightTimeId = flightTime.FlightTimeId }, flightTime);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{flightTimeId}")]
    public IActionResult UpdateFlightTime(int flightTimeId, [FromBody] FlightTime flightTime)
    {
        try
        {
            var existingFlightTime = _flightTimeService.GetFlightTimeById(flightTimeId);
            if (existingFlightTime == null)
                return NotFound();

            flightTime.FlightTimeId = flightTimeId;
            _flightTimeService.UpdateFlightTime(flightTime);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{flightTimeId}")]
    public IActionResult DeleteFlightTime(int flightTimeId)
    {
        try
        {
            var existingFlightTime = _flightTimeService.GetFlightTimeById(flightTimeId);
            if (existingFlightTime == null)
                return NotFound();

            _flightTimeService.DeleteFlightTime(flightTimeId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
