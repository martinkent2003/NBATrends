using API.Data;
using API.Data.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//api/drafthistories
    public class DraftHistoriesController : ControllerBase
    {
        private readonly DataContext _context;
        public DraftHistoriesController (DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DraftHistory>> GetDraftHistories()
        {
            var draftHistories = _context.DraftHistories.FromSqlRaw("SELECT * FROM DraftHistory").ToList();
            return draftHistories;
        }

        [HttpGet("firstOverallPicksCarreerAverage/attribute/{attribute}")] //api/drafthistories/firstOverallPicksCarreerAverage/attribute/Points
        public ActionResult<IEnumerable<FirstOverallPickCarrerStat>> GetFirstOverallPicksAndAttribute(string attribute){
            var query = $"SELECT dh.SeasonId AS SeasonId, p.FirstName AS FirstName, p.LastName AS LastName, ROUND (AVG(pbs.{attribute}), 2) AS AvgAttribute "+
                        "FROM PlayerBoxScore pbs " +
                        "JOIN DraftHistory dh ON pbs.PlayerId = dh.PersonId " +
                        "JOIN Player p ON dh.PersonId = p.PersonId " +
                        "WHERE dh.OverallPick = 1 " +
                        "GROUP BY dh.PersonId, dh.SeasonId, p.FirstName, p.LastName " +
                        "ORDER BY SeasonId DESC " ;
            
            var firstOverallPicksAndAttribute = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(g => new { g.SeasonId, g.FirstName, g.LastName, g.AvgAttribute })
                .ToList();
            return Ok(firstOverallPicksAndAttribute);
        }

    }
}