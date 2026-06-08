using LiveMatch.Application.Services;

using Microsoft.AspNetCore.Mvc;

namespace LiveMatch.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly TeamService _teamService;
   
    public TeamsController(TeamService teamService)
    {
        _teamService = teamService;
       
    }

  

    [HttpGet("league/{leagueId}")]
    public async Task<IActionResult> GetTeamsByLeague(int leagueId)
    {
        var teams = await _teamService.GetTeamsByLeagueAsync(leagueId);
        return Ok(teams);
    }

    [HttpGet("{teamId}/players")]
    public async Task<IActionResult> GetTeamWithPlayers(int teamId)
    {
        var team = await _teamService.GetTeamWithPlayersAsync(teamId);
        return Ok(team);
    }
}