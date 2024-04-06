using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommonPlayerInfoController : ControllerBase
    {
        private readonly DataContext _context;

        public CommonPlayerInfoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommonPlayerInfo>> GetPlayerInfo()
        {
            var playerInfo = _context.CommonPlayerInfos.FromSqlRaw("SELECT * FROM CommonPlayerInfo").ToList();
            return playerInfo;
        }
    }
}