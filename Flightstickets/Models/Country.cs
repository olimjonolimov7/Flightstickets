using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flightstickets.Models;
[Table("countries")]
public class Country
{
    [Key]
    [Column("country_id")]
    public int CountryId { get; set; }

    [Required]
    [StringLength(100)]
    [Column("country_name")]
    public string CountryName { get; set; }
}
