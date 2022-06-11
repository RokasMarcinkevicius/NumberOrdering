using Microsoft.AspNetCore.Http;
using Moq;
using NumberOrdering.Repository.Services;
using NumberOrdering.Services.Services;

namespace NumberOrdering.Tests
{
    public class BusinessServiceTest
    {
        private readonly BusinessService _businessService;
        private NumberSorterService _mockNumberSorterService;
        private Mock<FileService> _mockFileService;

        public BusinessServiceTest()
        {
            _mockNumberSorterService = new NumberSorterService();
            _mockFileService = new Mock<FileService>(null);
            _businessService = new BusinessService(_mockNumberSorterService, _mockFileService.Object, null);
        }

        private IFormFile GetIFormFile()
        {
            //Setup mock file using a memory stream
            var content = "[0,1,2,3,4,6]";
            var fileName = "test";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            return new FormFile(stream, 0, stream.Length, "test", fileName);
        }

        // For public List<int> ImportNumberList(IFormFile file)
        [Fact]
        public void ImportNumberListCallsImportsFile()
        {
            // Arrange + Act
            try
            {
                _businessService.ImportNumberList(GetIFormFile());
            }
            catch (ArgumentNullException)
            {
                // TODO Find a better way to setup IFormFile
            }
            // Assert
            finally
            {
                _mockFileService.Verify(m => m.ConvertFileToString(It.IsAny<IFormFile>()), Times.Once());
            }

        }

        // For public List<int> ImportNumberList(List<int> numberList, string fileName)
        [Fact]
        public void ImportNumberListReturnsOrderedList()
        {
            // Arrange a
            List<int> numberList = new List<int>(new int[] { 1, 3, 4, 2, 7 });
            List<int> sortedList = new List<int>(new int[] { 1, 2, 3, 4, 7 });
            string fileName = "Mock";

            // Act + Assert
            Assert.Equal(_businessService.ImportNumberList(numberList, fileName), sortedList);
            _mockFileService.Verify(m => m.SaveToFile(It.IsAny<List<int>>(), It.IsAny<string>()), Times.Once());
        }
    }
}
