using API.Data;
using API.Data.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("yearlyAveragePerPositionStats/attribute/{attribute}/position/{position}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetYearlyAveragePerPositionStats(string attribute, string position){
            var query = $"SELECT EXTRACT (YEAR FROM g.GameDate) AS Year, ROUND (AVG(pbs.{attribute}),2) as AvgAttribute " +
                        "FROM Game g " +
                        "JOIN PlayerBoxScore pbs ON g.GameId = pbs.GameId " +
                        "JOIN CommonPlayerInfo cpi ON pbs.PlayerId = cpi.PersonId " +
                        $"WHERE cpi.Position = '{position}' " +
                        "GROUP BY EXTRACT (YEAR FROM g.GameDate) "+
                        "ORDER BY EXTRACT (YEAR FROM g.GameDate) ";   

            var yearlyAveragePerPositionStats = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(r => new {
                    r.Year,
                    r.AvgAttribute
                })
                .ToList();
            return Ok(yearlyAveragePerPositionStats);
        }
        [HttpGet("AvgAttributeByHeight/attribute/{attribute}")]
        public ActionResult<IEnumerable<CommonPlayerInfo>> GetAvgAttributeByHeight(string attribute){
            var query = $"SELECT Heights AS StringAttribute, Decade AS StringAttribute2, ROUND( AVG({attribute}), 2) AS AvgAttribute "+
                        "FROM ( "+
                            "SELECT "+
                                "CASE "+
                                    "WHEN cpi.HEIGHT < 72 THEN 'Under 6 feet' "+
                                    "WHEN cpi.HEIGHT BETWEEN 72 AND 77 THEN '6-6.5 ft' "+
                                    "WHEN cpi.HEIGHT BETWEEN 78 AND 83 THEN '6.5-7 ft' "+
                                    "WHEN cpi.HEIGHT BETWEEN 84 AND 89 THEN '7-7.5 ft' "+
                                    "ELSE '7.5+ ft' "+
                                "END AS Heights, "+
                                "CASE "+
                                    "WHEN EXTRACT(YEAR FROM g.GAMEDATE) BETWEEN 1940 AND 1949 THEN '1940s' "+
                                    "WHEN EXTRACT(YEAR FROM g.GAMEDATE) BETWEEN 1950 AND 1959 THEN '1950s' "+
                                    "WHEN EXTRACT(YEAR FROM g.GAMEDATE) BETWEEN 1960 AND 1969 THEN '1960s' "+
                                    "WHEN EXTRACT(YEAR FROM g.GAMEDATE) BETWEEN 1970 AND 1979 THEN '1970s' "+
                                    "WHEN EXTRACT(YEAR FROM g.GAMEDATE) BETWEEN 1980 AND 1989 THEN '1980s' "+
                                    "WHEN EXTRACT(YEAR FROM g.GAMEDATE) BETWEEN 1990 AND 1999 THEN '1990s' "+
                                    "WHEN EXTRACT(YEAR FROM g.GAMEDATE) BETWEEN 2000 AND 2009 THEN '2000s' "+
                                    "WHEN EXTRACT(YEAR FROM g.GAMEDATE) BETWEEN 2010 AND 2019 THEN '2010s' "+
                                    "ELSE '2020s' "+
                                "END AS Decade, "+
                                $"pb.{attribute} "+
                            "FROM "+
                                "PlayerBoxScore pb "+
                            "JOIN "+
                                "CommonPlayerInfo cpi ON pb.PLAYERID = cpi.PERSONID "+
                            "JOIN "+
                                "Game g ON pb.GAMEID = g.GAMEID "+
                        ") HeightGroups "+
                        "GROUP BY "+
                            "Heights, Decade "+
                        "ORDER BY "+
                            "Decade, Heights";
            var AvgAttrByHeight = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(r=>new{
                    r.StringAttribute,
                    r.StringAttribute2,
                    r.AvgAttribute
                })
                .ToList();

            return Ok(AvgAttrByHeight);
        }

        [HttpGet("TotalTuples")]
        public ActionResult<IEnumerable<CommonPlayerInfo>> TotalTuples(){
            var query = "SELECT SUM(TotalRows) AS IntAttribute "+
                        "FROM ( "+
                            "SELECT COUNT(*) AS TotalRows FROM Player "+
                            "UNION ALL "+
                            "SELECT COUNT(*) AS TotalRows FROM Team "+
                            "UNION ALL "+
                            "SELECT COUNT(*) AS TotalRows FROM Game "+
                            "UNION ALL "+
                            "SELECT COUNT(*) AS TotalRows FROM PlayerBoxScore "+
                            "UNION ALL "+
                            "SELECT COUNT(*) AS TotalRows FROM DraftHistory "+
                            "UNION ALL "+
                            "SELECT COUNT(*) AS TotalRows FROM CommonPlayerInfo "+
                        ") TableCounts";
            
            var Tuples = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(r=>new{
                    r.IntAttribute,
                })
                .ToList();

            return Ok(Tuples);
        }

    }
}