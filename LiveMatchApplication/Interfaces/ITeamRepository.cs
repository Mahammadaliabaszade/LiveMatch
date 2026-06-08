using LiveMatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Application.Interfaces;

public interface ITeamRepository : IGenericRepository<Team>
{
    Task<IEnumerable<Team>> GetTeamsByLeagueAsync(int leagueId);
    Task<Team> GetTeamWithPlayersAsync(int teamId);
}