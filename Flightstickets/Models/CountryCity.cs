using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flightstickets.Models;
[Table("country_city")]
public class CountryCity
{
    [Key]
    [Column("country_city_id")]
    public int CountryCityId { get; set; }

    [Column("country_id")]
    public int CountryId { get; set; }

    [Column("city_id")]
    public int CityId { get; set; }

    [ForeignKey("CityId")]
    public City City { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }
}
