using InteractiveFootballBoxScore_WASM.PbpParser.Models;

namespace InteractiveFootballBoxScore_WASM.PbpParser.Libraries
{
    /// <summary>
    /// Reference for different team metadata (endzone colors, etc)
    /// </summary>
    public static class TeamLibrary
    {
        public static Dictionary<TeamAcronym, Team> teamDictionary = new Dictionary<TeamAcronym, Team>
        {
            { TeamAcronym.ARI, new Team{ Name = "Arizona", Nickname = "Cardinals", PrimaryColor = "#97233F", SecondaryColor = "#000000", Acronym = TeamAcronym.ARI} },
            { TeamAcronym.GNB, new Team{ Name = "Green Bay", Nickname = "Packers", PrimaryColor = "#203731", SecondaryColor = "#FFB612", Acronym = TeamAcronym.GNB} },
            { TeamAcronym.SFO, new Team{ Name = "San Francisco", Nickname = "49ers", PrimaryColor = "#AA0000", SecondaryColor = "#B3995D", Acronym = TeamAcronym.SFO} },
            { TeamAcronym.CLE, new Team{ Name = "Cleveland", Nickname = "Browns", PrimaryColor = "#311D00", SecondaryColor = "#ff3c00", Acronym = TeamAcronym.SFO} },
            { TeamAcronym.CHI, new Team{ Name = "Chicago", Nickname = "Bears", PrimaryColor = "#0B162A", SecondaryColor = "#c83803", Acronym = TeamAcronym.SFO} },
        };
    }
}
