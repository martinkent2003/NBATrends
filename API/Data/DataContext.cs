using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<CommonPlayerInfo> CommonPlayerInfos{ get; set;}
    public DbSet<DraftHistory> DraftHistories { get; set; }
    public DbSet<Game> Games { get; set; }
}
