using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6LetterWordChallenge.Models;
using _6LetterWordChallenge.Services.Interfaces;

namespace _6LetterWordChallenge.Services
{
    public class ViewerService : IViewerService
    {
        public void ShowCombinations(IEnumerable<Combination> combinations)
        {
            if (!combinations.Any())
            {
                throw new InvalidOperationException("No combinations were found.");
            }

            foreach (var combination in combinations)
            {
                var viewData = combination.Word1 + "+" + combination.Word2 + "=" + combination.Result;
                Console.WriteLine(viewData);
            }
        }
    }
}
