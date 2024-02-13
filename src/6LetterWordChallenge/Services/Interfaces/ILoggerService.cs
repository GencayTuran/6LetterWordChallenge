using Microsoft.Extensions.Logging;

namespace _6LetterWordChallenge.Services.Interfaces
{
    public interface ILoggerService
    {
        Task<ILoggerFactory> CreateLoggerFactory();

        //Task<List<Logger<T>>> CreateLoggers() where T is class;
    }
}