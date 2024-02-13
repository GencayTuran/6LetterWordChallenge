using _6LetterWordChallenge.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Services
{
    public class LoggerService : ILoggerService
    {
        public async Task<ILoggerFactory> CreateLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
        }
    }
}
