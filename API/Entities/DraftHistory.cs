using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace API.Entities;

public class DraftHistory
{
    [Key]
    [ForeignKey("PersonId")]
    [NotNull]
    public int PersonId { get; set; }
    [NotNull]
    public int SeasonId { get; set; }
    public int RoundNumber { get; set; }
    public int RoundPick { get; set; }
    public int OverallPick { get; set; }

    [ForeignKey("TeamId")]
    [NotNull]
    public int TeamId { get; set; }
    public string Organization { get; set; }
    public string OrganizationType { get; set; }
    public int PlayerProfileFlag { get; set; }
    //foreign
}
