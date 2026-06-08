using LiveMatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Application.Interfaces;

public interface IMatchRepository : IGenericRepository<Match>
{
    Task<IEnumerable<Match>> GetLiveMatchesAsync();
    Task<IEnumerable<Match>> GetMatchesByLeagueAsync(int leagueId);
    Task<Match> GetMatchWithLineupAsync(int matchId);
}
