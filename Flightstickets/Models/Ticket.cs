using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flightstickets.Models;
[Table("tickets")]
public class Ticket
{
    [Key]
    [Column("ticket_id")]
    public int TicketId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("flights_time_id")]
    public int FlightsTimeId { get; set; }

    [ForeignKey("FlightsTimeId")]
    public FlightTime FlightTime { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
