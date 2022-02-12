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
            { TeamAcronym.ARI, new Team{ Name = "Arizona Cardinals", PrimaryColor = "#97233F", SecondaryColor = "#000000"} },
            { TeamAcronym.GNB, new Team{ Name = "Green Bay Packers", PrimaryColor = "#203731", SecondaryColor = "#FFB612"} },
            { TeamAcronym.SFO, new Team{ Name = "San Francisco 49ers", PrimaryColor = "#AA0000", SecondaryColor = "#B3995D"} },
        };
    }
}
