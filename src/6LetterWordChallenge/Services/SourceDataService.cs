using _6LetterWordChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Services
{
    public class SourceDataService : ISourceDataService
    {
        public string GetFilePath()
        {
            //Get base directory path in order to go up from that level to the github root where input.txt is located.
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..", "input.txt"));
        }

        public async Task<string[]> ReadDataFromFile(string filePath)
        {
            return await File.ReadAllLinesAsync(filePath);
        }
    }
}
