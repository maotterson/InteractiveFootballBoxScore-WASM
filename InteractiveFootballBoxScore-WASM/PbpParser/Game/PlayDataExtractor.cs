using InteractiveFootballBoxScore_WASM.PbpParser.Libraries;

namespace PlayByPlayParser.Game
{
    public class PlayDataExtractor
    {
        public static bool IsHomePossessionAtKickoff(string locationString, TeamAcronym homeAcronym)
        {
            if (locationString.Contains(homeAcronym.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
