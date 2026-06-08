using LiveMatch.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveMatch.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly PlayerService _playerService;

    public PlayersController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet("team/{teamId}")]
    public async Task<IActionResult> GetPlayersByTeam(int teamId)
    {
        var players = await _playerService.GetPlayersByTeamAsync(teamId);
        return Ok(players);
    }

    [HttpGet("{playerId}")]
    public async Task<IActionResult> GetPlayerById(int playerId)
    {
        var player = await _playerService.GetPlayerByIdAsync(playerId);
        return Ok(player);
    }
}