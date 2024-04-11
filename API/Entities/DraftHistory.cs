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
    public string Organization { get; set; }
    public string OrganizationType { get; set; }
    public int PlayerProfileFlag { get; set; }

    [ForeignKey("PersonId")]
    public virtual Player Player { get; set; }
    
    [ForeignKey("TeamId")]
    public virtual Team Team { get; set; }
}
