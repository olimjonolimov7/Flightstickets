using Flightstickets.Models;
using System.Collections.Generic;

public interface IFlightService
{
    List<Flight> GetAllFlights();
    Flight GetFlightById(int flightId);
    void AddFlight(Flight flight);
    void UpdateFlight(Flight flight);
    void DeleteFlight(int flightId);
}
