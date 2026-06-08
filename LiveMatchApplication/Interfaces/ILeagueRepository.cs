using LiveMatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Application.Interfaces;

public interface ILeagueRepository : IGenericRepository<League>
{
    Task<League> GetLeagueWithTeamsAsync(int leagueId);
}