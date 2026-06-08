using LiveMatchDomain.Common;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LiveMatch.Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Country { get; set; }
    public int ApiFootballId { get; set; }

    public int LeagueId { get; set; }
    public League League { get; set; }

    public ICollection<Player> Players { get; set; }
}