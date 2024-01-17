﻿using Flightstickets.Models;
using System.Collections.Generic;

public interface ITicketService
{
    List<Ticket> GetAllTickets();
    Ticket GetTicketById(int ticketId);
    void AddTicket(Ticket ticket);
    void UpdateTicket(Ticket ticket);
    void DeleteTicket(int ticketId);
}
