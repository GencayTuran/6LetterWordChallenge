using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6LetterWordChallenge.Services.Interfaces;

namespace _6LetterWordChallenge.Services
{
    public class ProgramRerunnerService : IProgramRerunnerService
    {
        public async Task<bool> RerunProgram()
        {
            Console.WriteLine("Press any key to rerun the program or 'Q' to quit.");
            var key = Console.ReadKey().Key;

            return key != ConsoleKey.Q;
        }
    }
}
