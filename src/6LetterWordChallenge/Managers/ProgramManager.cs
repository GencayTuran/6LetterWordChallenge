using _6LetterWordChallenge.Services.Interfaces;
using _6LetterWordChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6LetterWordChallenge.Managers.Interfaces;
using Microsoft.Extensions.Logging;

namespace _6LetterWordChallenge.Managers
{
    public class ProgramManager : IProgramManager
    {
        private readonly ISourceDataService _sourceData;
        private readonly ICombinatorService _dataCombinator;
        private readonly IViewerService _viewData;
        private readonly IProgramRerunnerService _programRerunner;
        private readonly ILogger<ProgramManager> _logger;

        public ProgramManager(
            ISourceDataService sourceData,
            ICombinatorService dataCombinator,
            IViewerService viewData,
            IProgramRerunnerService programRerunner,
            ILogger<ProgramManager> logger)
        {
            _sourceData = sourceData;
            _dataCombinator = dataCombinator;
            _viewData = viewData;
            _programRerunner = programRerunner;
            _logger = logger;
        }

        public async Task Run()
        {
            bool rerun = true;
            while (rerun)
            {
                try
                {
                    _logger.LogInformation("Getting file path.");
                    var filePath = _sourceData.GetFilePath();

                    _logger.LogInformation("Reading data from path.");
                    var inputData = await _sourceData.ReadDataFromFile(filePath);

                    _logger.LogInformation("Combining data.");
                    var combinations = _dataCombinator.CombineData(inputData);

                    _logger.LogInformation("Printing combinations.");
                    _viewData.ShowCombinations(combinations);

                    //Set to false if program runs without errors
                    rerun = false;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.LogWarning(ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.LogWarning(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Check your file.");
                    _logger.LogWarning(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unknown error occured:");
                    Console.WriteLine(ex.Message);
                    _logger.LogWarning(ex.Message);
                }

                if (!await _programRerunner.RerunProgram())
                {
                    rerun = false;
                }
            }
        }
    }
}
