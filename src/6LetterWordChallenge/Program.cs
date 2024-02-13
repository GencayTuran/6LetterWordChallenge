using _6LetterWordChallenge.Managers;
using _6LetterWordChallenge.Services;
using _6LetterWordChallenge.Services.Interfaces;
using Microsoft.Extensions.Logging;

ILoggerService loggerService = new LoggerService();
var loggerFactory = await loggerService.CreateLoggerFactory();

//Logger instances
var loggerProgramManager = loggerFactory.CreateLogger<ProgramManager>();

//Service instances
IFileWrapper fileWrapper = new FileWrapper();
ISourceDataService sourceDataService = new SourceDataService(fileWrapper);
ICombinatorService datacombinatorService = new CombinatorService();
IViewerService viewDataService = new ViewerService();
IProgramRerunnerService programRerunnerService = new ProgramRerunnerService();

ProgramManager programManager = 
    new (sourceDataService, datacombinatorService, viewDataService, programRerunnerService, loggerProgramManager);

await programManager.Run();