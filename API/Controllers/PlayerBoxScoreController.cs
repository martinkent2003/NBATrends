using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

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
    }
}