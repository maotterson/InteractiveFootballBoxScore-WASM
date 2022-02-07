using PlayByPlayParser.Models;

namespace InteractiveFootballBoxScore_WASM.Services
{
    public interface IPlayService
    {
        Task ChangePlay(Play play);
    }
}
