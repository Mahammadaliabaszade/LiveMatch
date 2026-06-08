using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Application.DTOs.Match;

public class MatchDto
{
    public int Id { get; set; }
    public string Round { get; set; } = string.Empty;

    public string HomeTeamName { get; set; }
    public string HomeTeamLogo { get; set; }
    public string AwayTeamName { get; set; }
    public string AwayTeamLogo { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public DateTime MatchDate { get; set; }
    public string Status { get; set; }
    public string LeagueName { get; set; }
}