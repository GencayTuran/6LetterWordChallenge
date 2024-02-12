using _6LetterWordChallenge.Models;

namespace _6LetterWordChallenge.Services.Interfaces
{
    public interface ICombinatorService
    {
        IEnumerable<Combination> CombineData(string[] inputData);
    }
}