using API.Data;
using API.Data.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerBoxScoreController : ControllerBase
    {
        private readonly DataContext _context;
        public PlayerBoxScoreController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerBoxScore>> GetGames(){
            var boxScores = _context.PlayerBoxScores.FromSqlRaw("SELECT * FROM PlayerBoxScore where GameId=29400122;").ToList();
            return boxScores;
        }

        [HttpGet("yearlyAveragePerPositionStats/attribute/{attribute}/position/{position}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetYearlyAveragePerPositionStats(string attribute, string position){
            var query = $"SELECT EXTRACT (YEAR FROM g.GameDate) AS Year, ROUND (AVG(pbs.{attribute}),2) as AvgAttribute " +
                        "FROM Game g " +
                        "JOIN PlayerBoxScore pbs ON g.GameId = pbs.GameId " +
                        "JOIN CommonPlayerInfo cpi ON pbs.PlayerId = cpi.PersonId " +
                        $"WHERE cpi.Position = '{position}' " +
                        "GROUP BY EXTRACT (YEAR FROM g.GameDate) "+
                        "ORDER BY EXTRACT (YEAR FROM g.GameDate) ";   

            var yearlyAveragePerPositionStats = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(r => new {
                    r.Year,
                    r.AvgAttribute
                })
                .ToList();
            return Ok(yearlyAveragePerPositionStats);
        }
    }
}