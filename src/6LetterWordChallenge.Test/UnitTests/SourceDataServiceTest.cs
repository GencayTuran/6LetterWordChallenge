using _6LetterWordChallenge.Services;
using _6LetterWordChallenge.Services.Interfaces;
using Moq;

namespace _6LetterWordChallenge.Test.UnitTests
{
    [TestClass]
    public class SourceDataServiceTest
    {
        private readonly ISourceDataService _sourceDataService;
        private readonly Mock<IFileWrapper> _mockFileWrapper;
        public SourceDataServiceTest()
        {
            _mockFileWrapper = new Mock<IFileWrapper>();
            _sourceDataService = new SourceDataService(_mockFileWrapper.Object);
        }

        [TestMethod]
        public void SourceDataService_GetFilePath_ContainsValidPath()
        {
            //Arrange
            var correctPathEnding = "6LetterWordChallenge\\input.txt";

            //Act
            var result = _sourceDataService.GetFilePath();

            //Assert
            Assert.IsTrue(result.Contains(correctPathEnding));
        }

        [TestMethod]
        public async Task SourceDataService_ReadDataFromFile_ReturnsStringCollection()
        {
            //Arrange
            var filePath = _sourceDataService.GetFilePath();
            var mockCollection = new string[] { "a", "b", "c" };
            _mockFileWrapper.Setup(f => f.ReadAllLinesAsync(filePath)).ReturnsAsync(mockCollection);

            //Act
            var data = await _sourceDataService.ReadDataFromFile(filePath);

            //Assert
            Assert.IsNotNull(data, "Data is null");
            Assert.IsTrue(data.Length > 0, "Data array is empty");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task SourceDataService_ReadDataFromFile_ThrowsArgumentNullException()
        {
            //Arrange
            var filePath = _sourceDataService.GetFilePath();
            _mockFileWrapper.Setup(f => f.ReadAllLinesAsync(filePath)).ReturnsAsync(new string[] { });

            //Act
            var result = await _sourceDataService.ReadDataFromFile(filePath);
        }
        
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public async Task SourceDataService_ReadDataFromFile_ThrowsFileNotFoundException()
        {
            //Act
            await _sourceDataService.ReadDataFromFile("nonexistentfile.txt");
        }
    }
}