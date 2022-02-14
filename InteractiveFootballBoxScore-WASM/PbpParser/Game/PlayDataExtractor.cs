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

        public static int extractLocationInt(string locationString, TeamAcronym homeAcronym)
        {
            string[] splitLocation = locationString.Split(" ");

            string locationAcronym = splitLocation[0];
            int yardLine = int.Parse(splitLocation[1]);

            if(locationAcronym == homeAcronym.ToString())
            {
                return yardLine;
            }
            return 100 - yardLine;

        }
    }
}
