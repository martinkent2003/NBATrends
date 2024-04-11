using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/teams
public class TeamsController : ControllerBase
{
    private readonly DataContext _context;

    public TeamsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Team>> GetTeams()
    {
        var teams = _context.Teams.FromSqlRaw("SELECT * FROM Team").ToList();
        return teams;
    }
}
