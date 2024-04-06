using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace API.Entities;
public class CommonPlayerInfo
{
    [Key]
    [ForeignKey("PlayerId")]
    [NotNull]
    public int? PersonId { get; set; }

    [ForeignKey("TeamId")]
    public int? TeamId{ get; set;}
    public string? Country { get; set; }
    public string? School { get; set; }
    public int? FromYear { get; set; }
    public int? ToYear { get; set; }
    public string? Position { get; set; }
    public int? PlayerWeight { get; set; }
    public int? Height { get; set; }
    public int? JerseyNum { get; set; }
    public int? Seasons { get; set; }
    public int? Greatest75Flag{ get; set;}
    public int? DLeagueFlag{ get; set;}
    public DateOnly? BirthDate{ get; set;}
}
