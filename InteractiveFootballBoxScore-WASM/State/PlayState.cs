using PlayByPlayParser.Models;

namespace InteractiveFootballBoxScore_WASM.State
{
    public class PlayState
    {
        public Play CurrentPlay { get; private set; }

        public event Action OnChange;

        public void SetCurrentPlay(Play play)
        {
            CurrentPlay = play;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
