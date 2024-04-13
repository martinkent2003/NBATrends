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
        // List of valid column names to ensure the query is safe from SQL injection
        var validColumns = new HashSet<string> {"TeamId",
                                                "FullName",
                                                "Abbreviation",
                                                "Nickname",
                                                "YearFounded",
                                                "Facebook",
                                                "Instagram",
                                                "Twitter" }; // Add actual valid column names here

        if (!validColumns.Contains(attribute))
        {
            return BadRequest("Invalid attribute name.");
        }

        var query = $"SELECT {attribute} FROM Team";
        var teamAttributes = _context.Teams
            .FromSqlRaw(query)
            .Select(t => EF.Property<string>(t, attribute)) // Dynamically access the property
            .ToList();
        return Ok(teamAttributes);
    }
}
