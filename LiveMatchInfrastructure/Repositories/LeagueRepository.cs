using LiveMatch.Application.Interfaces;
using LiveMatch.Domain.Entities;
using LiveMatch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LiveMatch.Infrastructure.Repositories;

public class LeagueRepository : GenericRepository<League>, ILeagueRepository
{
    public LeagueRepository(LiveMatchDbContext context) : base(context)
    {
    }

    public async Task<League> GetLeagueWithTeamsAsync(int leagueId)
    {
        return await _context.Leagues
            .Include(l => l.Teams)
            .FirstOrDefaultAsync(l => l.Id == leagueId);
    }
}