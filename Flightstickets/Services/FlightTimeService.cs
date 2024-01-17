using Flightstickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flightstickets.Services;

public class FlightTimeService : IFlightTimeService
{
    private readonly ApplicationDbContext _dbContext;

    public FlightTimeService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<FlightTime> GetAllFlightTimes()
    {
        return _dbContext.FlightTimes.ToList();
    }

    public FlightTime GetFlightTimeById(int flightTimeId)
    {
        return _dbContext.FlightTimes.Find(flightTimeId);
    }

    public void AddFlightTime(FlightTime flightTime)
    {
        _dbContext.FlightTimes.Add(flightTime);
        _dbContext.SaveChanges();
    }

    public void UpdateFlightTime(FlightTime flightTime)
    {
        _dbContext.FlightTimes.Update(flightTime);
        _dbContext.SaveChanges();
    }

    public void DeleteFlightTime(int flightTimeId)
    {
        var flightTime = _dbContext.FlightTimes.Find(flightTimeId);
        if (flightTime != null)
        {
            _dbContext.FlightTimes.Remove(flightTime);
            _dbContext.SaveChanges();
        }
    }
}
