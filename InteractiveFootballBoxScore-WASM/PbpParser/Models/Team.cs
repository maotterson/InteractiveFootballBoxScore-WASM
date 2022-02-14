using InteractiveFootballBoxScore_WASM.PbpParser.Libraries;

namespace InteractiveFootballBoxScore_WASM.PbpParser.Models
{
    public class Team
    {
        public string? Name { get; set; }
        public string? Nickname { get; set; }
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
        public TeamAcronym Acronym { get; set; }
    }
}
