using API.Data;
using API.Data.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly DataContext _context;
        public GamesController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetGames(){
            var games = _context.Games.FromSqlRaw("SELECT * FROM Game;").ToList();
            return games;
        }
        
        [HttpGet("season/{seasonId}/team/{teamId}")]
        public ActionResult<IEnumerable<Game>> GetSeasonTeamGames(int seasonId, int teamId){
            var seasonTeamGames = _context.Games.FromSqlRaw("SELECT * FROM Game WHERE SeasonId = :seasonId AND (HTeamId = :teamId OR ATeamId = :teamId)",
                new OracleParameter("seasonId", seasonId),
                new OracleParameter("teamId", teamId)).ToList();
            return seasonTeamGames;
        }

        [HttpGet("homePoints/team/{team}/fromYear/{fromYear}/toYear/{toYear}")]
        public ActionResult<IEnumerable<DateAndPoints>> GetHomePointsTeamGames(int team, string fromYear, string toYear){
            //get game stat for a team for each game in date rage
            
            var query = 
                "SELECT HPoints, GameDate "+
                "FROM Game "+
                $"WHERE HTeamId = {team} "+
                $"AND GameDate BETWEEN TO_DATE({fromYear}, 'YYYY') AND TO_DATE({toYear}, 'YYYY')";

            var seasonAverage = _context
                .Games
                .FromSqlRaw(query)
                            .Select(DateAndPoints => new DateAndPoints{
                                GameDate = DateAndPoints.GameDate,
                                HPoints = DateAndPoints.HPoints
                            })
                            .ToList();
            
            return Ok(seasonAverage);
        }

        [HttpGet("homeAttr/{attribute}/team/{team}/fromYear/{fromYear}/toYear/{toYear}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetAttributeForTeamHomeGames(string attribute, int team, string fromYear, string toYear){
            //get game stat for a team for each game in date rage
            
            var query = 
                $"SELECT * "+
                "FROM Game "+
                $"WHERE HTeamId = {team} "+
                $"AND GameDate BETWEEN TO_DATE({fromYear}, 'YYYY') AND TO_DATE({toYear}, 'YYYY')";
            //help me here pls 
            var seasonAverage = _context
                .Games
                .FromSqlRaw(query)
                .Select(DateAndAttribute => new DateAndAttribute{
                    GameAttribute = GetAttributeValue(DateAndAttribute, attribute),
                    GameDate = DateAndAttribute.GameDate
                })
                .ToList();
            
            return Ok(seasonAverage);
        }

        [HttpGet("playoff")]
        public ActionResult<IEnumerable<Game>> GetPlayoffGames(){
            var playoffGames = _context.Games.FromSqlRaw("SELECT * FROM Game g WHERE g.SeasonType = 'Playoffs';").ToList();
            return playoffGames;
        }
        private static dynamic GetAttributeValue(Game game, string attribute)
        {
            switch (attribute)
            {
                case "HPoints":
                    return game.HPoints;
                case "APoints":
                    return game.APoints;
                case "HFieldGoalsMade":
                    return game.HFieldGoalsMade;
                case "AFieldGoalsMade":
                    return game.AFieldGoalsMade;
                case "HFieldGoalsAttempted":
                    return game.HFieldGoalsAttempted;
                case "AFieldGoalsAttempted":
                    return game.AFieldGoalsAttempted;
                case "HFieldGoalPercentage":
                    return game.HFieldGoalPercentage;
                case "AFieldGoalPercentage":
                    return game.AFieldGoalPercentage;
                case "HFgThreesMade":
                    return game.HFgThreesMade;
                case "AFgThreesMade":
                    return game.AFgThreesMade;
                case "HFgThreesAttempted":
                    return game.HFgThreesAttempted;
                case "AFgThreesAttempted":
                    return game.AFgThreesAttempted;
                case "HFgThreePercentage":
                    return game.HFgThreePercentage;
                case "AFgThreePercentage":
                    return game.AFgThreePercentage;
                case "HFreeThrowsMade":
                    return game.HFreeThrowsMade;
                case "AFreeThrowsMade":
                    return game.AFreeThrowsMade;
                case "HFreeThrowsAttemped":
                    return game.HFreeThrowsAttemped;
                case "AFreeThrowsAttemped":
                    return game.AFreeThrowsAttemped;
                case "HFreeThrowPercentage":
                    return game.HFreeThrowPercentage;
                case "AFreeThrowPercentage":
                    return game.AFreeThrowPercentage;
                case "HOffensiveRebounds":
                    return game.HOffensiveRebounds;
                case "AOffensiveRebounds":
                    return game.AOffensiveRebounds;
                case "HDefensiveRebounds":
                    return game.HDefensiveRebounds;
                case "ADefensiveRebounds":
                    return game.ADefensiveRebounds;
                case "HRebounds":
                    return game.HRebounds;
                case "ARebounds":
                    return game.ARebounds;
                case "HAssists":
                    return game.HAssists;
                case "AAssists":    
                    return game.AAssists;
                case "HSteals":
                    return game.HSteals;
                case "ASteals":
                    return game.ASteals;
                case "HBlocks":   
                    return game.HBlocks;    
                case "ABlocks":   
                    return game.ABlocks;    
                case "HTurnovers":
                    return game.HTurnovers;
                case "ATurnovers":      
                    return game.ATurnovers; 
                case "HPersonalFouls":
                    return game.HPersonalFouls;
                case "APersonalFouls":  
                    return game.APersonalFouls;
                case "HPlusMinus":
                    return game.HPlusMinus;
                case "APlusMinus":  
                    return game.APlusMinus;
                case "HWinLoss":
                    return game.HWinLoss;
                case "AWinLoss":    
                    return game.AWinLoss;   
                
                default:
                    return null;
            }
        }
    }
    
}