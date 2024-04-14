using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class PlayerBoxScore
    {
        [Key]
        public int PlayerId { get; set; }
        
        [Required]
        public int TeamId { get; set; }
        
        [Required]
        public int GameId { get; set; }
        
        public int? Mins { get; set; }
        
        public int? FieldGoalsMade { get; set; }
        
        public int? FieldGoalsAttempted { get; set; }
        
        public double? FieldGoalPercentage { get; set; }
        
        public int? FgThreesMade { get; set; }
        
        public int? FgThreesAttempted { get; set; }
        
        public double? FgThreesPercentage { get; set; }
        
        public int? FreeThrowsMade { get; set; }
        
        public int? FreeThrowsAttempted { get; set; }
        
        public double? FreeThrowPercentage { get; set; }
        
        public int? OffensiveRebounds { get; set; }
        
        public int? DefensiveRebounds { get; set; }
        
        public int? Rebounds { get; set; }
        
        public int? Assists { get; set; }
        
        public int? Steals { get; set; }
        
        public int? Blocks { get; set; }
        
        public int? Turnovers { get; set; }
        
        public int? PersonalFouls { get; set; }
        
        public int? Points { get; set; }
        
        public int? PlusMinus { get; set; }
        
        public string? StartPosition { get; set;}
    }
}
