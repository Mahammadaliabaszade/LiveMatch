using LiveMatch.Application.DTOs.Team;
using LiveMatch.Application.Interfaces;

namespace LiveMatch.Application.Services;

public class TeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<TeamDto>> GetTeamsByLeagueAsync(int leagueId)
    {
        var teams = await _teamRepository.GetTeamsByLeagueAsync(leagueId);
        return teams.Select(t => new TeamDto
        {
            Id = t.Id,
            Name = t.Name,
            Logo = t.Logo,
            Country = t.Country,
            LeagueName = t.League.Name
        });
    }

    public async Task<TeamDto> GetTeamWithPlayersAsync(int teamId)
    {
        var team = await _teamRepository.GetTeamWithPlayersAsync(teamId);
        return new TeamDto
        {
            Id = team.Id,
            Name = team.Name,
            Logo = team.Logo,
            Country = team.Country,
            LeagueName = team.League.Name
        };
    }
}