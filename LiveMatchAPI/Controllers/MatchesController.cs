using LiveMatch.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveMatch.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchesController : ControllerBase
{
    private readonly MatchService _matchService;
    


    public MatchesController(MatchService matchService)
    {
        _matchService = matchService;
        
    }

    [HttpGet("live")]
    public async Task<IActionResult> GetLiveMatches()
    {
        var matches = await _matchService.GetLiveMatchesAsync();
        return Ok(matches);
    }

    [HttpGet("league/{leagueId}")]
    public async Task<IActionResult> GetMatchesByLeague(int leagueId)
    {
        var matches = await _matchService.GetMatchesByLeagueAsync(leagueId);
        return Ok(matches);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMatchById(int id)
    {
        var match = await _matchService.GetMatchByIdAsync(id);
        return Ok(match);
    }


}