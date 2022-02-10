using PlayByPlayParser.Models;

namespace InteractiveFootballBoxScore_WASM.PbpParser.Models
{
    /// <summary>
    /// Game Data
    /// 
    /// In addition to play-by-play, information about teams must be extracted
    /// </summary>
    public class Game
    {
        public Team? Home { get; set; }
        public Team? Away { get; set; }
        public List<Play>? PlayList { get; set; }

    }
}
