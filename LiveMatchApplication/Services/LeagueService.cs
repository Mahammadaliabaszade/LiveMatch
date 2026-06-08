using LiveMatch.Application.DTOs.League;
using LiveMatch.Application.Interfaces;

namespace LiveMatch.Application.Services;

public class LeagueService
{
    private readonly ILeagueRepository _leagueRepository;

    public LeagueService(ILeagueRepository leagueRepository)
    {
        _leagueRepository = leagueRepository;
    }

    public async Task<IEnumerable<LeagueDto>> GetAllLeaguesAsync()
    {
        var leagues = await _leagueRepository.GetAllAsync();
        return leagues.Select(l => new LeagueDto
        {
            Id = l.Id,
            Name = l.Name,
            Country = l.Country,
            Logo = l.Logo
        });
    }

    public async Task<LeagueDto> GetLeagueByIdAsync(int leagueId)
    {
        var league = await _leagueRepository.GetByIdAsync(leagueId);
        return new LeagueDto
        {
            Id = league.Id,
            Name = league.Name,
            Country = league.Country,
            Logo = league.Logo
        };
    }
}