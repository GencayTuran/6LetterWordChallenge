using _6LetterWordChallenge.Models;
using _6LetterWordChallenge.Services.Interfaces;
using _6LetterWordChallenge.Services;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Test.UnitTests
{
    [TestClass]
    public class ViewerServiceTests
    {
        private readonly IViewerService _viewerService;

        public ViewerServiceTests()
        {
            _viewerService = new ViewerService();
        }

        [TestMethod]
        public void ViewerService_ShowCombinations_DisplaysCombinations()
        {
            // Arrange
            var combinations = new List<Combination>
        {
            new Combination { Word1 = "word1", Word2 = "word2", Result = "word1word2" },
            new Combination { Word1 = "abc", Word2 = "def", Result = "abcdef" }
        };

            // Act
            using (var consoleOutput = new ConsoleOutput())
            {
                _viewerService.ShowCombinations(combinations);

                // Assert
                var consoleOutputText = consoleOutput.GetOutput();
                Assert.IsTrue(consoleOutputText.Contains("word1+word2=word1word2"));
                Assert.IsTrue(consoleOutputText.Contains("abc+def=abcdef"));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ViewerService_ShowCombinations_ThrowsInvalidOperationException()
        {
            // Arrange
            var emptyCombinations = Enumerable.Empty<Combination>();

            // Act
            _viewerService.ShowCombinations(emptyCombinations);
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            stringWriter.Dispose();
            Console.SetOut(originalOutput);
        }
    }
}
