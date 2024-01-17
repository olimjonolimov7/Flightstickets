using Flightstickets.Models;
using System.Collections.Generic;

public interface IFlightTimeService
{
    List<FlightTime> GetAllFlightTimes();
    FlightTime GetFlightTimeById(int flightTimeId);
    void AddFlightTime(FlightTime flightTime);
    void UpdateFlightTime(FlightTime flightTime);
    void DeleteFlightTime(int flightTimeId);
}
