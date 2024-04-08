
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Entities;

public class Player
{
    [Key]
    [NotNull]
    public int PersonId { get; set; }
    [NotNull]
    public string FirstName { get; set; }
    [NotNull]
    public string LastName { get; set; }
    [NotNull]
    public int IsActive { get; set; }
}
