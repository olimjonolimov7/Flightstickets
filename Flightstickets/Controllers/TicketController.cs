using Flightstickets.Models;
using Flightstickets.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]/[action]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> GetAllTickets()
    {
        try
        {
            var tickets = _ticketService.GetAllTickets();
            return Ok(tickets);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{ticketId}")]
    public ActionResult<Ticket> GetTicketById(int ticketId)
    {
        try
        {
            var ticket = _ticketService.GetTicketById(ticketId);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public ActionResult<Ticket> AddTicket([FromBody] Ticket ticket)
    {
        try
        {
            _ticketService.AddTicket(ticket);
            return CreatedAtAction(nameof(GetTicketById), new { ticketId = ticket.TicketId }, ticket);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{ticketId}")]
    public IActionResult UpdateTicket(int ticketId, [FromBody] Ticket ticket)
    {
        try
        {
            var existingTicket = _ticketService.GetTicketById(ticketId);
            if (existingTicket == null)
                return NotFound();

            ticket.TicketId = ticketId;
            _ticketService.UpdateTicket(ticket);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{ticketId}")]
    public IActionResult DeleteTicket(int ticketId)
    {
        try
        {
            var existingTicket = _ticketService.GetTicketById(ticketId);
            if (existingTicket == null)
                return NotFound();

            _ticketService.DeleteTicket(ticketId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
