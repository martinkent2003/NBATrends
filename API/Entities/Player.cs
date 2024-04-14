
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Player
{
    [Key]
    [Required]
    public int PersonId { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public int IsActive { get; set; }

     //used for SQL generated attributes(like AVG, SUM, etc.)
    public double? DoubleAttribute { get; set; }
    public int? IntAttribute { get; set; }
    public string? StringAttribute { get; set; }
    public int? Year { get; set; }
    public double? AvgAttribute { get; set; }
}
