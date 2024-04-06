using API.Data;
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
    }
}