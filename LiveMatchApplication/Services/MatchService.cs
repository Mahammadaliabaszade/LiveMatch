using LiveMatch.Application.DTOs.Match;
using LiveMatch.Application.Interfaces;

namespace LiveMatch.Application.Services;

public class MatchService
{
    private readonly IMatchRepository _matchRepository;

    public MatchService(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<IEnumerable<MatchDto>> GetLiveMatchesAsync()
    {
        var matches = await _matchRepository.GetLiveMatchesAsync();
        return matches.Select(m => new MatchDto
        {
            Id = m.Id,
            HomeTeamName = m.HomeTeam.Name,
            HomeTeamLogo = m.HomeTeam.Logo,
            AwayTeamName = m.AwayTeam.Name,
            AwayTeamLogo = m.AwayTeam.Logo,
            HomeScore = m.HomeScore,
            AwayScore = m.AwayScore,
            MatchDate = m.MatchDate,
            Status = m.Status.ToString(),
            LeagueName = m.League.Name,
            Round = m.Round
        });
    }

    public async Task<IEnumerable<MatchDto>> GetMatchesByLeagueAsync(int leagueId)
    {
        var matches = await _matchRepository.GetMatchesByLeagueAsync(leagueId);
        return matches.Select(m => new MatchDto
        {
            Id = m.Id,
            HomeTeamName = m.HomeTeam.Name,
            HomeTeamLogo = m.HomeTeam.Logo,
            AwayTeamName = m.AwayTeam.Name,
            AwayTeamLogo = m.AwayTeam.Logo,
            HomeScore = m.HomeScore,
            AwayScore = m.AwayScore,
            MatchDate = m.MatchDate,
            Status = m.Status.ToString(),
            LeagueName = m.League.Name,
            Round = m.Round
        });
    }

    public async Task<MatchDto> GetMatchByIdAsync(int id)
    {
        var match = await _matchRepository.GetMatchWithLineupAsync(id);
        return new MatchDto
        {
            Id = match.Id,
            HomeTeamName = match.HomeTeam.Name,
            HomeTeamLogo = match.HomeTeam.Logo,
            AwayTeamName = match.AwayTeam.Name,
            AwayTeamLogo = match.AwayTeam.Logo,
            HomeScore = match.HomeScore,
            AwayScore = match.AwayScore,
            MatchDate = match.MatchDate,
            Status = match.Status.ToString(),
            LeagueName = match.League.Name,
            Round = match.Round
        };
    }
}