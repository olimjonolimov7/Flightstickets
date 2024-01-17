using Flightstickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flightstickets.Services;
    public class FlightService : IFlightService
    {
        private readonly ApplicationDbContext _dbContext;

        public FlightService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Flight> GetAllFlights()
        {
            return _dbContext.Flights.ToList();
        }

        public Flight GetFlightById(int flightId)
        {
            return _dbContext.Flights.Find(flightId);
        }

        public void AddFlight(Flight flight)
        {
            _dbContext.Flights.Add(flight);
            _dbContext.SaveChanges();
        }

        public void UpdateFlight(Flight flight)
        {
            _dbContext.Flights.Update(flight);
            _dbContext.SaveChanges();
        }

        public void DeleteFlight(int flightId)
        {
            var flight = _dbContext.Flights.Find(flightId);
            if (flight != null)
            {
                _dbContext.Flights.Remove(flight);
                _dbContext.SaveChanges();
            }
        }
    }
