using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flightstickets.Models;
[Table("flights")]
public class Flight
{
    [Key]
    [Column("flight_id")]
    public int FlightId { get; set; }

    [Column("departure_city_id")]
    public int DepartureCityId { get; set; }

    [Column("destination_city_id")]
    public int DestinationCityId { get; set; }

    [Column("seat_amount")]
    public int SeatAmount { get; set; }

    [StringLength(100)]
    [Column("flight_number")]
    public string FlightNumber { get; set; }

    [ForeignKey("DepartureCityId")]
    public City DepartureCity { get; set; }

    [ForeignKey("DestinationCityId")]
    public City DestinationCity { get; set; }
}
