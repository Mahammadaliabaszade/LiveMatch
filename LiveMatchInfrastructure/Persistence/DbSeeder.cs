using LiveMatch.Domain.Entities;
using LiveMatchDomain.Enums;
using System.Text.Json;

namespace LiveMatch.Infrastructure.Persistence;

public static class DbSeeder
{
    public static async Task SeedAsync(LiveMatchDbContext context)
    {
        if (context.Leagues.Any()) return;

        var leagues = new Dictionary<string, League>
        {
            { "en.1", new League { Name = "Premier League", Country = "ENG", Logo = "https://images.fotmob.com/image_resources/logo/leaguelogo/dark/47.png", ApiFootballId = 47, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow } },
            { "es.1", new League { Name = "LaLiga", Country = "ESP", Logo = "https://images.fotmob.com/image_resources/logo/leaguelogo/dark/87.png", ApiFootballId = 87, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow } },
            { "de.1", new League { Name = "Bundesliga", Country = "GER", Logo = "https://images.fotmob.com/image_resources/logo/leaguelogo/dark/54.png", ApiFootballId = 54, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow } },
            { "it.1", new League { Name = "Serie A", Country = "ITA", Logo = "https://images.fotmob.com/image_resources/logo/leaguelogo/dark/55.png", ApiFootballId = 55, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow } },
            { "fr.1", new League { Name = "Ligue 1", Country = "FRA", Logo = "https://images.fotmob.com/image_resources/logo/leaguelogo/dark/53.png", ApiFootballId = 53, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow } }
        };

        await context.Leagues.AddRangeAsync(leagues.Values);
        await context.SaveChangesAsync();

        var dataPath = Path.Combine(AppContext.BaseDirectory, "Data");

        foreach (var (fileName, league) in leagues)
        {
            var filePath = Path.Combine(dataPath, $"{fileName}.json");
            if (!File.Exists(filePath)) continue;

            var json = await File.ReadAllTextAsync(filePath);
            var jsonDoc = JsonDocument.Parse(json);

            var teamNames = new HashSet<string>();
            var teams = new Dictionary<string, Team>();

            var matchesEl = jsonDoc.RootElement.GetProperty("matches").EnumerateArray();
            foreach (var match in matchesEl)
            {
                var homeName = match.GetProperty("team1").GetString()!;
                var awayName = match.GetProperty("team2").GetString()!;
                teamNames.Add(homeName);
                teamNames.Add(awayName);
            }

            foreach (var teamName in teamNames)
            {
                var team = new Team
                {
                    Name = teamName,
                    Country = league.Country,
                    Logo = "",
                    ApiFootballId = 0,
                    LeagueId = league.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                teams[teamName] = team;
            }

            await context.Teams.AddRangeAsync(teams.Values);
            await context.SaveChangesAsync();

            matchesEl = jsonDoc.RootElement.GetProperty("matches").EnumerateArray();
            foreach (var match in matchesEl)
            {
                var homeName = match.GetProperty("team1").GetString()!;
                var awayName = match.GetProperty("team2").GetString()!;
                var dateStr = match.GetProperty("date").GetString()!;

                int homeScore = 0, awayScore = 0;
                MatchStatus status = MatchStatus.Finished;

                if (match.TryGetProperty("score", out var scoreEl))
                {
                    if (scoreEl.ValueKind == JsonValueKind.Object)
                    {
                        if (scoreEl.TryGetProperty("ft", out var ft))
                        {
                            var ftArray = ft.EnumerateArray().ToList();
                            if (ftArray.Count == 2)
                            {
                                homeScore = ftArray[0].GetInt32();
                                awayScore = ftArray[1].GetInt32();
                            }
                        }
                    }
                    else if (scoreEl.ValueKind == JsonValueKind.Array)
                    {
                        var ftArray = scoreEl.EnumerateArray().ToList();
                        if (ftArray.Count == 2)
                        {
                            homeScore = ftArray[0].GetInt32();
                            awayScore = ftArray[1].GetInt32();
                        }
                    }
                }
                else
                {
                    status = MatchStatus.NotStarted;
                }

                var newMatch = new Match
                {
                    LeagueId = league.Id,
                    HomeTeamId = teams[homeName].Id,
                    AwayTeamId = teams[awayName].Id,
                    HomeScore = homeScore,
                    AwayScore = awayScore,
                    MatchDate = DateTime.SpecifyKind(DateTime.Parse(dateStr), DateTimeKind.Utc),
                    Status = status,
                    ApiFootballId = 0,
                    Round = match.TryGetProperty("round", out var roundEl) ? roundEl.GetString() ?? "" : "",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await context.Matches.AddAsync(newMatch);
            }

            await context.SaveChangesAsync();
        }
    }
}