using LiveMatch.Application.Interfaces;
using LiveMatch.Domain.Entities;
using LiveMatchDomain.Enums;
using LiveMatch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LiveMatch.Infrastructure.Repositories;

public class MatchRepository : GenericRepository<Match>, IMatchRepository
{
    public MatchRepository(LiveMatchDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Match>> GetLiveMatchesAsync()
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Include(m => m.League)
            .Where(m => m.Status == MatchStatus.Live)
            .ToListAsync();
    }

    public async Task<IEnumerable<Match>> GetMatchesByLeagueAsync(int leagueId)
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Include(m => m.League)
            .Where(m => m.LeagueId == leagueId)
            .ToListAsync();
    }

    public async Task<Match> GetMatchWithLineupAsync(int matchId)
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Include(m => m.League)
            .Include(m => m.Lineups)
                .ThenInclude(l => l.Player)
            .FirstOrDefaultAsync(m => m.Id == matchId);
    }
}