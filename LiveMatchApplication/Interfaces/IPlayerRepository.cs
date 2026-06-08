using LiveMatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Application.Interfaces;

public interface IPlayerRepository : IGenericRepository<Player>
{
    Task<IEnumerable<Player>> GetPlayersByTeamAsync(int teamId);
}
