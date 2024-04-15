using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Entities;


public class Team
{
    [Key]
    public int TeamId { get; set; } 
    [Required]
    public string? FullName { get; set; } 
    [Required]
    public string? Abbreviation { get; set; } //char[3]
    [Required]
    public string? Nickname { get; set; } 
    public int YearFounded { get; set; }
    public string? Facebook { get; set; }
    public string? Instagram { get; set; }
    public string? Twitter { get; set; }    
}

