using LiveMatch.Application.Interfaces;
using LiveMatch.Domain.Entities;
using LiveMatch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LiveMatch.Infrastructure.Repositories;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
    public TeamRepository(LiveMatchDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Team>> GetTeamsByLeagueAsync(int leagueId)
    {
        return await _context.Teams
            .Include(t => t.League)
            .Where(t => t.LeagueId == leagueId)
            .ToListAsync();
    }

    public async Task<Team> GetTeamWithPlayersAsync(int teamId)
    {
        return await _context.Teams
            .Include(t => t.League)
            .Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.Id == teamId);
    }
}