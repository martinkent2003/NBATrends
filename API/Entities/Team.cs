using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Entities;


public class Team
{
    [Key]
    [NotNull]
    public int TeamId { get; set; } 
    [NotNull]
    public string? FullName { get; set; } 
    [NotNull]
    public string? Abbreviation { get; set; } //char[3]
    [NotNull]
    public string? Nickname { get; set; } 
    public int? YearFounded { get; set; }
    public string? Facebook { get; set; }
    public string? Instagram { get; set; }
    public string? Twitter { get; set; }    
}

