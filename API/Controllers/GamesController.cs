using API.Data;
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

        [HttpGet("playoff")]
        public ActionResult<IEnumerable<Game>> GetPlayoffGames(){
            var playoffGames = _context.Games.FromSqlRaw("SELECT * FROM Game g WHERE g.SeasonType = 'Playoffs';").ToList();
            return playoffGames;
        }
    }
}