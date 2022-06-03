using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NumberOrdering.Services.Interfaces
{
    public interface IFileService
    {
        public bool SaveToFile(List<int> numbers, string fileName);
        public List<int> LoadLatestFile(string fileName = null);
        public string ConvertFileToString(IFormFile file);
    }
}
