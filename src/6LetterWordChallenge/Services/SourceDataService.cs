using _6LetterWordChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Services
{
    public class SourceDataService : ISourceDataService
    {
        private readonly IFileWrapper _fileWrapper;
        public SourceDataService(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public string GetFilePath()
        {
            //Get base directory path in order to go up from that level to the github root where input.txt is located.
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..", "input.txt"));
        }

        public async Task<string[]> ReadDataFromFile(string filePath)
        {
            var data = await _fileWrapper.ReadAllLinesAsync(filePath);
            if (!data.Any())
            {
                throw new ArgumentNullException($"No data found in file path {filePath}.");
            }
            return data;
        }
    }
}
