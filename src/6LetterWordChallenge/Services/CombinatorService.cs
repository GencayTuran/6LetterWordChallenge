using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6LetterWordChallenge.Models;
using _6LetterWordChallenge.Services.Interfaces;

namespace _6LetterWordChallenge.Services
{
    public class CombinatorService : ICombinatorService
    {
        public IEnumerable<Combination> CombineData(string[] inputData)
        {
            var existingWords = inputData.Where(data => data.Length == 6).ToArray();
            var toBeCombinedWords = inputData.Where(data => data.Length < 6 && data.Length > 0).ToArray();

            if (!existingWords.Any() || !toBeCombinedWords.Any())
            {
                throw new InvalidOperationException("One or more amounts of combinations or characters were not found in the file.");
            }

            var combinedWords = from word1 in toBeCombinedWords
                                from word2 in toBeCombinedWords
                                where word1 != word2
                                let combined = word1 + word2
                                where existingWords.Contains(combined, StringComparer.OrdinalIgnoreCase)
                                select new Combination { Word1 = word1, Word2 = word2, Result = combined };

            return combinedWords;
        }
    }
}
