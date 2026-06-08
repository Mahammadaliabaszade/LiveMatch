using LiveMatch.Domain.Entities;
using LiveMatchDomain.Common;
using LiveMatchDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Domain.Entities
{
   

    public class Match : BaseEntity
    {
        public int LeagueId { get; set; }
        public string Round { get; set; } = string.Empty;

        public League League { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public DateTime MatchDate { get; set; }
        public MatchStatus Status { get; set; }
        public int ApiFootballId { get; set; }

        public ICollection<MatchLineup> Lineups { get; set; }
    }
}
