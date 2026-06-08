using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Application.DTOs.League;

public class LeagueDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Logo { get; set; }
}
