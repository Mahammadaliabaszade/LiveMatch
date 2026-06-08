using LiveMatchDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Domain.Entities;

public class MatchLineup : BaseEntity
{
    public int MatchId { get; set; }
    public Match Match { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }

    public int PlayerId { get; set; }
    public Player Player { get; set; }

    public bool IsStarting { get; set; }
    public int ShirtNumber { get; set; }
}
