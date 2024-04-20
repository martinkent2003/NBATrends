using API.Data.DTOs;
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
    public DbSet<PlayerBoxScore> PlayerBoxScores{ get; set;}
    public DbSet<QueryResultAttributes> QueryResultAttributes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<QueryResultAttributes>().HasNoKey();
    }
}
