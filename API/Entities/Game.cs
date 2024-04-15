using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        
        [Required]
        public int SeasonId { get; set; }
        
        public string? SeasonType { get; set; }
        
        public DateTime? GameDate { get; set; }
        
        [Required]
        public int HTeamId { get; set; }
        
        public int? HWinLoss { get; set; }
        
        public int? HFieldGoalsMade { get; set; }
        
        public int? HFieldGoalsAttempted { get; set; }
        
        public double? HFieldGoalPercentage { get; set; }
        
        public int? HFgThreesMade { get; set; }
        
        public int? HFgThreesAttempted { get; set; }
        
        public double? HFgThreePercentage { get; set; }
        
        public int? HFreeThrowsMade { get; set; }
        
        public int? HFreeThrowsAttempted { get; set; }
        
        public double? HFreeThrowPercentage { get; set; }
        
        public int? HOffensiveRebounds { get; set; }
        
        public int? HDefensiveRebounds { get; set; }
        
        public int? HRebounds { get; set; }
        
        public int? HAssists { get; set; }
        
        public int? HSteals { get; set; }
        
        public int? HBlocks { get; set; }
        
        public int? HTurnovers { get; set; }
        
        public int? HPersonalFouls { get; set; }
        
        public int? HPoints { get; set; }
        
        public int? HPlusMinus { get; set; }
        
        [Required]
        public int ATeamId { get; set; }
        
        public int? AWinLoss { get; set; }
        
        public int? AFieldGoalsMade { get; set; }
        
        public int? AFieldGoalsAttempted { get; set; }
        
        public double? AFieldGoalPercentage { get; set; }
        
        public int? AFgThreesMade { get; set; }
        
        public int? AFgThreesAttempted { get; set; }
        
        public double? AFgThreePercentage { get; set; }
        
        public int? AFreeThrowsMade { get; set; }
        
        public int? AFreeThrowsAttempted { get; set; }
        
        public double? AFreeThrowPercentage { get; set; }
        
        public int? AOffensiveRebounds { get; set; }
        
        public int? ADefensiveRebounds { get; set; }
        
        public int? ARebounds { get; set; }
        
        public int? AAssists { get; set; }
        
        public int? ASteals { get; set; }
        
        public int? ABlocks { get; set; }
        
        public int? ATurnovers { get; set; }
        
        public int? APersonalFouls { get; set; }
        
        public int? APoints { get; set; }
        
        public int? APlusMinus { get; set; }
        
        [ForeignKey("HTeamId")]
        public virtual Team? HomeTeam { get; set; }
        
        [ForeignKey("ATeamId")]
        public virtual Team? AwayTeam { get; set; }

    }
}
