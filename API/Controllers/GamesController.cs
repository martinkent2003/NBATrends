using API.Data;
using API.Data.DTOs;
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



        [HttpGet("homeGames/attribute/{attribute}/team/{team}/fromYear/{fromYear}/toYear/{toYear}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetAttributeForHomeGames(string attribute, int team, string fromYear, string toYear){
            var avgAttribute = "H" + attribute;

            var query = 
                $"SELECT EXTRACT(YEAR FROM GameDate) AS Year, ROUND(AVG({avgAttribute}),2) AS AvgAttribute "+
                "FROM Game "+
                $"WHERE HTeamId = {team} "+
                $"AND GameDate BETWEEN TO_DATE({fromYear}, 'YYYY') AND TO_DATE({toYear}, 'YYYY') "+
                "GROUP BY EXTRACT(YEAR FROM GameDate) " +
                "ORDER BY Year ASC ";

            var yearlyAverages = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(daa => new{
                    daa.Year,
                    daa.AvgAttribute
                })
                .ToList();
            
            return Ok(yearlyAverages);
        }

        [HttpGet("awayGames/attribute/{attribute}/team/{team}/fromYear/{fromYear}/toYear/{toYear}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetAttributeForAwayGames(string attribute, int team, string fromYear, string toYear){
            var avgAttribute = "A" + attribute;

            var query = 
                $"SELECT EXTRACT(YEAR FROM GameDate) AS Year, ROUND(AVG({avgAttribute}),2) AS AvgAttribute "+
                "FROM Game "+
                $"WHERE ATeamId = {team} "+
                $"AND GameDate BETWEEN TO_DATE({fromYear}, 'YYYY') AND TO_DATE({toYear}, 'YYYY') "+
                "GROUP BY EXTRACT(YEAR FROM GameDate) " +
                "ORDER BY Year ASC ";

            var yearlyAverages = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(daa => new{
                    daa.Year,
                    daa.AvgAttribute
                })
                .ToList();
            
            return Ok(yearlyAverages);
        }

        [HttpGet("allGames/attribute/{attribute}/team/{team}/fromYear/{fromYear}/toYear/{toYear}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetAttributeForAllGames(string attribute, int team, string fromYear, string toYear){
            //get game stat for a team for each game in date rage
            var homeAttr = "H" + attribute; 
            var awayAttr = "A" + attribute;

            var query = 
                "SELECT DoubleAttribute, GameDate FROM ("+
                $"SELECT {homeAttr} AS DoubleAttribute, GameDate " +
                "FROM Game " +
                $"WHERE HTeamId = {team} " +
                $"AND GameDate BETWEEN TO_DATE({fromYear}, 'YYYY') AND TO_DATE({toYear}, 'YYYY')"+
                "UNION " +
                $"SELECT {awayAttr} AS DoubleAttribute, GameDate " +
                "FROM Game " +
                $"WHERE ATeamId = {team} " +
                $"AND GameDate BETWEEN TO_DATE({fromYear}, 'YYYY') AND TO_DATE({toYear}, 'YYYY')"+
                ") ORDER BY GameDate ASC";


            var seasonAverage = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(daa => new{
                    daa.DoubleAttribute, 
                    daa.GameDate
                })
                .ToList();
            
            return Ok(seasonAverage);
        }

        //aggregate function for AVG() of an attribute
        [HttpGet("yearlyAverage/attribute/{attribute}/team/{team}/fromYear/{fromYear}/toYear/{toYear}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetAverageAttributeForAllGames(string attribute, int team, string fromYear, string toYear)
        {
            var homeAttr = "H" + attribute;
            var awayAttr = "A" + attribute;

            var query = 
                $"SELECT EXTRACT(YEAR FROM GameDate) AS Year, ROUND(AVG(attribute),2) AS AvgAttribute " +
                $"FROM (" +
                $"  SELECT {homeAttr} AS attribute, GameDate " +
                $"  FROM Game " +
                $"  WHERE HTeamId = {team} AND GameDate BETWEEN TO_DATE({fromYear}, 'YYYY') AND TO_DATE({toYear}, 'YYYY') " +
                $"  UNION ALL " + 
                $"  SELECT {awayAttr} AS attribute, GameDate " +
                $"  FROM Game " +
                $"  WHERE ATeamId = {team} AND GameDate BETWEEN TO_DATE({fromYear}, 'YYYY') AND TO_DATE({toYear}, 'YYYY')" +
                $") " +
                $"GROUP BY EXTRACT(YEAR FROM GameDate) " +
                $"ORDER BY Year ASC";

            
            var yearlyAverages = _context
                .QueryResultAttributes
                .FromSqlRaw(query).
                Select(daa => new{
                    daa.Year,
                    daa.AvgAttribute
                })
                .ToList();
            return Ok(yearlyAverages);
        }

        [HttpGet("AvgAttributePerDecadeSeasonal/attribute/{attribute}")]
        public ActionResult<IEnumerable<Game>> GetPtsAvgBySeasonPerDecade(string attribute){
            var homeAttr = "H" + attribute;
            var awayAttr = "A" + attribute;
            var query = 
                        "SELECT Decade AS StringAttribute2, Season_Type AS StringAttribute, ROUND(AVG((Home_Attribute + Away_Attribute) / 2),2) AS AvgAttribute "+
                        "FROM ("+
                            "SELECT "+
                                "CASE "+
                                    "WHEN EXTRACT(YEAR FROM g.Gamedate) BETWEEN 1940 AND 1949 THEN '1940s' "+
                                    "WHEN EXTRACT(YEAR FROM g.Gamedate) BETWEEN 1950 AND 1959 THEN '1950s' "+
                                    "WHEN EXTRACT(YEAR FROM g.Gamedate) BETWEEN 1960 AND 1969 THEN '1960s' "+
                                    "WHEN EXTRACT(YEAR FROM g.Gamedate) BETWEEN 1970 AND 1979 THEN '1970s' "+
                                    "WHEN EXTRACT(YEAR FROM g.Gamedate) BETWEEN 1980 AND 1989 THEN '1980s' "+
                                    "WHEN EXTRACT(YEAR FROM g.Gamedate) BETWEEN 1990 AND 1999 THEN '1990s' "+
                                    "WHEN EXTRACT(YEAR FROM g.Gamedate) BETWEEN 2000 AND 2009 THEN '2000s' "+
                                    "WHEN EXTRACT(YEAR FROM g.Gamedate) BETWEEN 2010 AND 2019 THEN '2010s' "+
                                    "ELSE '2020s' "+
                                "END AS Decade, "+
                                "CASE "+
                                    "WHEN g.SEASONTYPE = 'Regular Season' THEN 'Regular Season' "+
                                    "ELSE 'Playoffs' "+
                                "END AS Season_Type, "+
                                $"g.{homeAttr} AS Home_Attribute, "+
                                $"g.{awayAttr} AS Away_Attribute "+
                            "FROM "+
                                "Game g "+
                        ") "+
                        "GROUP BY "+
                            "Decade, "+
                            "Season_Type "+
                        "ORDER BY "+
                            "Decade, "+
                            "Season_Type ";
            
            var SeasonalAvgs = _context
                .QueryResultAttributes
                .FromSqlRaw(query)
                .Select(daa => new {
                    daa.StringAttribute2,
                    daa.StringAttribute,
                    daa.AvgAttribute
                })
                .ToList();
            return Ok(SeasonalAvgs);
        }

        [HttpGet("playoff")]
        public ActionResult<IEnumerable<Game>> GetPlayoffGames(){
            var playoffGames = _context.Games.FromSqlRaw("SELECT * FROM Game g WHERE g.SeasonType = 'Playoffs';").ToList();
            return playoffGames;
        }

        [HttpGet("yearlyOverStatByPosition/attribute/{attribute}/statistic/{statistic}/position/{position}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetYearlyOverStatByPosition(string attribute, string statistic, string position){
            var query = 
                $"SELECT EXTRACT(YEAR FROM g.GameDate) AS Year, COUNT(*) AS AvgAttribute "+
                "FROM PlayerBoxScore pbs " +
                "JOIN Game g ON pbs.GameId = g.GameId "+
                "JOIN CommonPlayerInfo cpi ON pbs.PlayerId = cpi.PersonId "+
                $"WHERE pbs.{attribute} > {statistic} " +
                $"AND cpi.Position = '{position}' "+
                "GROUP BY EXTRACT(YEAR FROM g.GameDate) "+
                "ORDER BY EXTRACT(YEAR FROM g.GameDate) ASC "; 

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

        [HttpGet("yearlyOverStatByPositionRatio/attribute/{attribute}/statistic/{statistic}/position/{position}")]
        public ActionResult<IEnumerable<DateAndAttribute>> GetYearlyOverStatByPositionRatioToYearlyGames(string attribute, string statistic, string position){
            var query = 
                "WITH GamesPerYear AS ( "+
                    "SELECT EXTRACT(YEAR FROM GameDate) AS Year, COUNT(*) AS TotalGames "+
                    "FROM Game "+
                    "GROUP BY EXTRACT(YEAR FROM GameDate) "+
                "), "+
                "NumGamesOverPositionStat AS ( "+
                    $"SELECT EXTRACT(YEAR FROM g.GameDate) AS Year, COUNT(*) AS AvgAttribute "+
                    "FROM PlayerBoxScore pbs " +
                    "JOIN Game g ON pbs.GameId = g.GameId "+
                    "JOIN CommonPlayerInfo cpi ON pbs.PlayerId = cpi.PersonId "+
                    $"WHERE pbs.{attribute} > {statistic} " +
                    $"AND cpi.Position = '{position}' "+
                    "GROUP BY EXTRACT(YEAR FROM g.GameDate) "+
                    "ORDER BY EXTRACT(YEAR FROM g.GameDate) ASC "+
                ") "+
                "SELECT gpy.Year, ROUND(ngop.AvgAttribute/gpy.TotalGames, 2) AS AvgAttribute "+
                "FROM GamesPerYear gpy "+
                "JOIN NumGamesOverPositionStat ngop ON gpy.Year = ngop.Year "+
                "ORDER BY gpy.Year ASC "; 

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

        
    }
    
}