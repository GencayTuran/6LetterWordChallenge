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
            try
            {
                var filePath = _sourceData.GetFilePath();
                var inputData = await _sourceData.ReadDataFromFile(filePath);
                var combinations = _dataCombinator.CombineData(inputData);

                _viewData.ShowCombinations(combinations);

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Check your file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unknown error occured:");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
