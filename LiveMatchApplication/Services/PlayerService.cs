using LiveMatch.Application.DTOs.Player;
using LiveMatch.Application.Interfaces;

namespace LiveMatch.Application.Services;

public class PlayerService
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<IEnumerable<PlayerDto>> GetPlayersByTeamAsync(int teamId)
    {
        var players = await _playerRepository.GetPlayersByTeamAsync(teamId);
        return players.Select(p => new PlayerDto
        {
            Id = p.Id,
            Name = p.Name,
            Position = p.Position,
            Number = p.Number,
            Nationality = p.Nationality,
            Age = p.Age,
            Photo = p.Photo,
            TeamName = p.Team.Name
        });
    }

    public async Task<PlayerDto> GetPlayerByIdAsync(int playerId)
    {
        var player = await _playerRepository.GetByIdAsync(playerId);
        return new PlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            Position = player.Position,
            Number = player.Number,
            Nationality = player.Nationality,
            Age = player.Age,
            Photo = player.Photo,
            TeamName = player.Team.Name
        };
    }
}