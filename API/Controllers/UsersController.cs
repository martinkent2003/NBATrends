using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.FromSql($"SELECT * FROM Users").ToList();
        return users;
    }
    
    [HttpGet("{id}")] // /api/users/3
    public ActionResult<AppUser?> GetUser(int id)
    {
        var user = _context.Users.FromSql($"SELECT * FROM USERS WHERE \"Id\" = {id}").FirstOrDefault();
        return user;
    }

}
