using LiveMatch.Application.Interfaces;
using LiveMatch.Domain.Entities;
using LiveMatch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LiveMatch.Infrastructure.Repositories;

public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
{
    public PlayerRepository(LiveMatchDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Player>> GetPlayersByTeamAsync(int teamId)
    {
        return await _context.Players
            .Include(p => p.Team)
            .Where(p => p.TeamId == teamId)
            .ToListAsync();
    }
}