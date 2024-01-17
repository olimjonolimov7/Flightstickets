
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flightstickets.Models;
[Table("flightstime")]
public class FlightTime
{
    [Key]
    [Column("flightstime_id")]
    public int FlightTimeId { get; set; }

    [Column("flight_id")]
    public int FlightId { get; set; }

    [Column("departure_time")]
    public DateTime DepartureTime { get; set; }

    [Column("destination_time")]
    public DateTime DestinationTime { get; set; }

    [ForeignKey("FlightId")]
    public Flight Flight { get; set; }
}
