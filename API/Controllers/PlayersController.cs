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
}
