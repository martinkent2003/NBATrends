
namespace API.Entities
{
    public class QueryResultAttributes
    {
         //used for SQL generated attributes(like AVG, SUM, etc.)
        public double? DoubleAttribute { get; set; }
        public int? IntAttribute { get; set; }
        public string? StringAttribute { get; set; }
        public string? StringAttribute2 { get; set;}
        public DateTime? GameDate { get; set; }
        public int? SeasonId { get; set; }
        public int? Year { get; set; }
        public double? AvgAttribute { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}