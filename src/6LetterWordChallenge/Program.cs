using _6LetterWordChallenge.Managers;
using _6LetterWordChallenge.Services;
using _6LetterWordChallenge.Services.Interfaces;

ISourceDataService sourceDataService = new SourceDataService();
ICombinatorService datacombinatorService = new CombinatorService();
IViewerService viewDataService = new ViewerService();

ProgramManager programManager = new (sourceDataService, datacombinatorService, viewDataService);
await programManager.Run();

Console.ReadLine();