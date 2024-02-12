using _6LetterWordChallenge.Services.Interfaces;
using _6LetterWordChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6LetterWordChallenge.Managers.Interfaces;

namespace _6LetterWordChallenge.Managers
{
    public class ProgramManager : IProgramManager
    {
        private readonly ISourceDataService _sourceData;
        private readonly ICombinatorService _dataCombinator;
        private readonly IViewerService _viewData;
        public ProgramManager(
            ISourceDataService sourceData,
            ICombinatorService dataCombinator,
            IViewerService viewData)
        {
            _sourceData = sourceData;
            _dataCombinator = dataCombinator;
            _viewData = viewData;
        }

        public async Task Run()
        {
            var filePath = _sourceData.GetFilePath();
            var inputData = await _sourceData.ReadDataFromFile(filePath);

            var combinations = _dataCombinator.CombineData(inputData);
            _viewData.ShowCombinations(combinations);
        }
    }
}
