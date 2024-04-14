using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class DraftHistory
{
    [Key]
    public int PersonId { get; set; }
    [Required]
    public int SeasonId { get; set; }
    public int RoundNumber { get; set; }
    public int RoundPick { get; set; }
    public int OverallPick { get; set; }

    [Required]
    public int TeamId { get; set; }
    public string? Organization { get; set; }
    public string? OrganizationType { get; set; }
    public int PlayerProfileFlag { get; set; }

    [ForeignKey("PersonId")]
    public virtual Player? Player { get; set; }
    
    [ForeignKey("TeamId")]
    public virtual Team? Team { get; set; }
    
    //for SQL generated attributes(like AVG, SUM, etc.)
     //used for SQL generated attributes(like AVG, SUM, etc.)
    public double? DoubleAttribute { get; set; }
    public int? IntAttribute { get; set; }
    public string? StringAttribute { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Year { get; set; }
    public double? AvgAttribute { get; set; }
}
