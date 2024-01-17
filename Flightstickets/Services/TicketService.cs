using Flightstickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flightstickets.Services;

public class TicketService : ITicketService
{
    private readonly ApplicationDbContext _dbContext;

    public TicketService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Ticket> GetAllTickets()
    {
        return _dbContext.Tickets.ToList();
    }

    public Ticket GetTicketById(int ticketId)
    {
        return _dbContext.Tickets.Find(ticketId);
    }

    public void AddTicket(Ticket ticket)
    {
        _dbContext.Tickets.Add(ticket);
        _dbContext.SaveChanges();
    }

    public void UpdateTicket(Ticket ticket)
    {
        _dbContext.Tickets.Update(ticket);
        _dbContext.SaveChanges();
    }

    public void DeleteTicket(int ticketId)
    {
        var ticket = _dbContext.Tickets.Find(ticketId);
        if (ticket != null)
        {
            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();
        }
    }
}
