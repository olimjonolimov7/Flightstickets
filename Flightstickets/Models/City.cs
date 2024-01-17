using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flightstickets.Models;
[Table("cities")]
public class City
{
    [Key]
    [Column("city_id")]
    public int CityId { get; set; }

    [Required]
    [StringLength(100)]
    [Column("city_name")]
    public string CityName { get; set; }
}
