using InteractiveFootballBoxScore_WASM.PbpParser.Libraries;

namespace InteractiveFootballBoxScore_WASM.PbpParser.Game
{
    public static class GameExtractor
    {
        /// <summary>
        /// Method to extract the team acronym from a field location in the play-by-play data
        /// example:
        /// Location: SFO 35 -> pulls out SFO acronym and returns true
        /// </summary>
        /// <param name="locationString">Location formatted string</param>
        /// <param name="foundAcronym">Extracted team acronym</param>
        /// <returns>True if successfully extracted, else false.</returns>
        public static bool TryExtractTeamFromLocation(string locationString, out TeamAcronym foundAcronym) {
            string acronymString = locationString.Split(" ")[0];
            try
            {
                foundAcronym = (TeamAcronym)Enum.Parse(typeof(TeamAcronym), acronymString);
                return true;
            }
            catch
            {
                foundAcronym = TeamAcronym.NOT_FOUND;
                return false;
            }
        }
    }
}
