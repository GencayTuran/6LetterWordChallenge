using _6LetterWordChallenge.Services.Interfaces;
using _6LetterWordChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Test.UnitTests
{
    [TestClass]
    public class CombinatorServiceTest
    {
        private readonly ICombinatorService _combinatorService;
        public CombinatorServiceTest()
        {
            _combinatorService = new CombinatorService();
        }

        [TestMethod]
        public void CombinatorService_CombineData_ReturnsCombinations()
        {
            // Arrange
            var inputData = new[]
            {
            "flight",
            "gabbie",
            "ga",
            "bbie",
            "python",
            "py",
            "thon"
        };

            // Act
            var combinations = _combinatorService.CombineData(inputData).ToList();

            // Assert
            Assert.IsNotNull(combinations, "Combinations are null");
            Assert.IsTrue(combinations.Count > 0, "No combinations found");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CombinatorService_CombineData_ThrowsInvalidOperationException()
        {
            // Arrange
            var inputData = new[]
            {
            "existing1",
            "existing2",
            // Missing "toBeCombined" data
            };

            // Act
            var combinations = _combinatorService.CombineData(inputData).ToList();
        }
    }
}
