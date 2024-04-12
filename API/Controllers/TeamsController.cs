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
    [HttpGet("names")]
    public ActionResult<IEnumerable<Team>> GetTeamNames(){
        var teamNames = _context.Teams.FromSqlRaw("SELECT FullName FROM Team")
                                                .Select(name => new { name.FullName })                  
                                                .ToList();
        return Ok(teamNames);
    }
    /*
    [HttpGet("attribute/{attribute}")]
    public ActionResult<IEnumerable<AnyType>> GetSpecificTeamAttribute(string attribute){
        var specificTeamAttribute = _context.Teams.FromSqlRaw($"SELECT {attribute} FROM Team").ToList();
        return specificTeamAttribute;
    }
    */
}
