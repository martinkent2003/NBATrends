using System.Diagnostics.CodeAnalysis;

namespace API.Entities
{
    public class PersonName
    {
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
    }
}