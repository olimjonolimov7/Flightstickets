using Flightstickets.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<FlightTime> FlightTimes { get; set; }
    public DbSet<CountryCity> CountryCities { get; set; }
    public DbSet<Ticket> Tickets { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
