using InteractiveFootballBoxScore_WASM.PbpParser.Models;
using PlayByPlayParser;
using PlayByPlayParser.Models;

namespace InteractiveFootballBoxScore_WASM.State
{
    public class GameState
    {
        public Game CurrentGame { get; private set; }

        public event Action OnChange;

        public async Task ProcessGameDataFromHTTP(HttpResponseMessage response)
        {
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
                }
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
