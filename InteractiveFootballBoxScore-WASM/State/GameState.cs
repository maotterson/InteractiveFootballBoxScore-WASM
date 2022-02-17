using InteractiveFootballBoxScore_WASM.PbpParser.Libraries;
using InteractiveFootballBoxScore_WASM.PbpParser.Models;
using PlayByPlayParser;
using PlayByPlayParser.Game;
using PlayByPlayParser.Models;

namespace InteractiveFootballBoxScore_WASM.State
{
    public class GameState
    {
        public Game? CurrentGame { get; private set; }

        public event Action OnChange;

        public async Task ProcessGameDataFromHTTP(HttpResponseMessage response)
        {
            // set to track extracted teams via acronym appearance
            HashSet<TeamAcronym> discoveredTeams = new HashSet<TeamAcronym>();

            CurrentGame = new Game()
            {
                PlayList = new List<Play>()
            };

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            using (var reader = new StreamReader(responseStream))
            {
                //skip header line
                reader.ReadLine();

                int index = 0;
                while (reader.EndOfStream == false)
                {
                    index++;
                    string[] data = reader.ReadLine().Split(",");
                    Play currentPlay = new Play
                    {
                        PlayIndex = index,
                        Quarter = data[0],
                        Time = data[1],
                        Down = data[2],
                        ToGo = data[3],
                        Location = data[4],
                        Summary = data[5],
                        PlayEvent = PlayEventFactory.ExtractPlayEvent(data[5])
                    };
                    CurrentGame.PlayList.Add(currentPlay);

                    if(discoveredTeams.Count < 2)
                    {
                        extractTeamFromCurrentPlay(currentPlay, discoveredTeams);
                    }
                }
                
                // assign home/away teams based on found teams during the play-by-play extraction
                CurrentGame.Home = TeamLibrary.teamDictionary[discoveredTeams.ElementAt(0)];
                CurrentGame.Away = TeamLibrary.teamDictionary[discoveredTeams.ElementAt(1)];
            }
            determineLocationInt();
            determinePossession();
        }
        private void determineLocationInt()
        {
            CurrentGame.PlayList.ForEach(play =>
            {
                play.LocationInt = PlayDataExtractor.extractLocationInt(play.Location, CurrentGame.Home.Acronym);
            });
        }
        private void determinePossession()
        {
            Play previousPlay = null;
            CurrentGame.PlayList.ForEach(play =>
            {
                if (previousPlay!=null && !previousPlay.IsResultChangeOfPossession)
                {
                    play.IsHomePossession = previousPlay.IsHomePossession;
                }
                else
                {
                    switch (play.PlayEvent.PlayType)
                    {
                        case "Kickoff":
                            play.IsHomePossession = PlayDataExtractor.IsHomePossessionAtKickoff(play.Location, CurrentGame.Home.Acronym);
                            break;
                        default:
                            break;
                    }
                }
                previousPlay = play;
            });
        }
        private void extractTeamFromCurrentPlay(Play currentPlay, HashSet<TeamAcronym> discoveredTeams)
        {
            bool isValidTeamAcronym = GameExtractor.TryExtractTeamFromLocation(currentPlay.Location, out TeamAcronym foundAcronym);
            if (isValidTeamAcronym)
            {
                discoveredTeams.Add(foundAcronym);
            }
        }

        public void SetCurrentGame(Game game)
        {
            CurrentGame = game;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
