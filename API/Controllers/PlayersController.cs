using API.Data;
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
        var firstOverallPicks = _context.Players.FromSqlRaw("SELECT * FROM Player p WHERE p.PersonId IN (SELECT dh.PersonId FROM DraftHistory dh WHERE dh.OverallPick = 1);").ToList();
        return firstOverallPicks;
    }

}
