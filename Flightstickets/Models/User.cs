using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Flightstickets.Models;

[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    [Column("password")]
    public string Password { get; set; }

    [Required]
    [StringLength(100)]
    [Column("firstname")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    [Column("lastname")]
    public string LastName { get; set; }

    [Required]
    [StringLength(100)]
    [Column("gender")]
    public string Gender { get; set; }

    [Required]
    [StringLength(100)]
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(100)]
    [Column("citizenship")]
    public string Citizenship { get; set; }

    [Column("date_of_birth")]
    public DateTime? DateOfBirth { get; set; }

    [Required]
    [StringLength(100)]
    [Column("country")]
    public string Country { get; set; }

    [Required]
    [StringLength(100)]
    [Column("username")]
    public string Username { get; set; }
}
