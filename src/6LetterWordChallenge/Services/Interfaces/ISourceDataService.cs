namespace _6LetterWordChallenge.Services.Interfaces
{
    public interface ISourceDataService
    {
        string GetFilePath();
        Task<string[]> ReadDataFromFile(string filePath);
    }
}