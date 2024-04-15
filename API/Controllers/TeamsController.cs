using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;


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
    [HttpGet("attribute/{attribute}")]
    public ActionResult<IEnumerable<string>> GetTeamAttribute(string attribute)
    {
        var validColumns = new HashSet<string> {"TeamId",
                                                "FullName",
                                                "Abbreviation",
                                                "Nickname",
                                                "YearFounded",
                                                "Facebook",
                                                "Instagram",
                                                "Twitter" };

        if (!validColumns.Contains(attribute))
        {
            return BadRequest("Invalid attribute name.");
        }

        var query = $"SELECT {attribute} FROM Team";
        var teamAttributes = _context.Teams
            .FromSqlRaw(query)
            .Select(t => EF.Property<string>(t, attribute)) 
            .ToList();
        return Ok(teamAttributes);
    }
}
