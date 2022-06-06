using NumberOrdering.Services.Interfaces;
using Xunit;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NumberOrdering.Repository.Interfaces;

namespace NumberOrdering.Tests
{
    public class BusinessServiceTest
    {
        // For public List<int> ImportNumberList(IFormFile file)
        [Fact]
        public void ImportNumberListCallsImportsFile()
        {
            // businessServiceMock.Setup(p => p.ImportNumberList(It.IsAny<List<int>>(), It.IsAny<string>())).Returns(It.IsAny<List<int>>);
            // standard setup, check if file import is called
        }

        [Fact]
        public void ImportNumberListWrongFileFormatThrowsException()
        {
            // setup incorrect file, must throw exception
        }

        [Fact]
        public void ImportNumberListSerializesFile()
        {
            // standard setup, check if serialization is called
        }

        [Fact]
        public void ImportNumberListFileReturnsOrderedList()
        {
            // standard setup, check if mock list input returns ordered mock list
        }

        [Fact]
        public void ImportNumberListFileCallsPerfomanceMeasurement()
        {
            // standard setup, check if perfomance measurement is called
        }

        // For public List<int> ImportNumberList(List<int> numberList, string fileName)
        [Fact]
        public void ImportNumberListReturnsOrderedList()
        {
            // standard setup, check if mock list input returns ordered mock list
        }

        [Fact]
        public void ImportNumberListCallsPerfomanceMeasurement()
        {
            // standard setup, check if perfomance measurement is called
        }

        [Fact]
        public void ImportNumberListCallsSaveToFile()
        {
            // standard setup, check if save to file function is called
        }
    }
}
