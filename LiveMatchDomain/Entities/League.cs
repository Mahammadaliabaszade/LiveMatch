using LiveMatchDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LiveMatch.Domain.Entities;

public class League : BaseEntity
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Logo { get; set; }
    public int ApiFootballId { get; set; }

    public ICollection<Team> Teams { get; set; }
    public ICollection<Match> Matches { get; set; }
}
