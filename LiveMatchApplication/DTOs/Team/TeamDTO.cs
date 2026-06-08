using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Application.DTOs.Team;

public class TeamDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Country { get; set; }
    public string LeagueName { get; set; }
}
