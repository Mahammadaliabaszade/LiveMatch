using System;
using System.Collections.Generic;
using System.Text;

using LiveMatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiveMatch.Infrastructure.Persistence;

public class LiveMatchDbContext : DbContext
{
    public LiveMatchDbContext(DbContextOptions<LiveMatchDbContext> options) : base(options)
    {
    }

    public DbSet<League> Leagues { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<MatchLineup> MatchLineups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
