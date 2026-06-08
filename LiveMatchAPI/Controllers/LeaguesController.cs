using LiveMatch.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveMatch.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaguesController : ControllerBase
{
    private readonly LeagueService _leagueService;
    

    public LeaguesController(LeagueService leagueService)
    {
        _leagueService = leagueService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLeagues()
    {
        var leagues = await _leagueService.GetAllLeaguesAsync();
        return Ok(leagues);
    }

    [HttpGet("{leagueId}")]
    public async Task<IActionResult> GetLeagueById(int leagueId)
    {
        var league = await _leagueService.GetLeagueByIdAsync(leagueId);
        return Ok(league);
    }

   
}