using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Services.Interfaces
{
    public interface IFileWrapper
    {
        Task<string[]> ReadAllLinesAsync(string path);
    }
}
