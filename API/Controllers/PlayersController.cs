using API.Data;
using API.Data.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly DataContext _context;
    public PlayersController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Player>> GetPlayers(){
        var players = _context.Players.FromSqlRaw("SELECT * FROM Player").ToList();
        return players;
    }

    [HttpGet("firstOverallPicks")] //api/players/firstOverallPicks
    public ActionResult<IEnumerable<Player>> GetFirstOverallPicks(){
        var firstOverallPicks = _context.Players
                                     .FromSqlRaw("SELECT p.FirstName " +
                                                 "FROM Player p " +
                                                 "JOIN DraftHistory dh ON p.PersonId = dh.PersonId " +
                                                 "WHERE dh.OverallPick = 1")
                                     .Select(player => new { player.FirstName })
                                     .ToList();
        return Ok(firstOverallPicks);
    }  

    [HttpGet("yearlyAverages/playerId/{playerId}/attribute/{attribute}")] //api/players/yearlyAverages/playerId/1
    public ActionResult<IEnumerable<DateAndAttribute>> GetYearlyAverage(int playerId, string attribute){

        var query = $"SELECT EXTRACT (YEAR FROM g.GameDate) AS Year, ROUND (AVG(pb.{attribute}),2) as AvgAttribute "+
                    "FROM Game g "+
                    "JOIN PlayerBoxScore pb ON g.GameId = pb.GameId "+
                    $"WHERE pb.PlayerId = {playerId} "+
                    "GROUP BY EXTRACT (YEAR FROM g.GameDate) "+
                    "ORDER BY EXTRACT (YEAR FROM g.GameDate) ";   

        var yearlyAverages = _context
            .QueryResultAttributes
            .FromSqlRaw(query)
            .Select(g => new { g.Year, g.AvgAttribute })
            .ToList();

        return Ok(yearlyAverages);
    }
}
