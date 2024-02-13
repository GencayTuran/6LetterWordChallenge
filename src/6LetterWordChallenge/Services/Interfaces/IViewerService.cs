using _6LetterWordChallenge.Models;

namespace _6LetterWordChallenge.Services.Interfaces
{
    public interface IViewerService
    {
        void ShowCombinations(IEnumerable<Combination> combinations);
    }
}