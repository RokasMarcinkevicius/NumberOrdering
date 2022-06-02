using NumberOrdering.Repository.Models;
using NumberOrdering.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NumberOrdering.Services.Services
{
    internal class FileService : IFileService
    {
        public int LoadFileContent(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool SaveToFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public List<int> LoadLatestFile()
        {
            List<int> numbers = new List<int>();
            var configuration = ConfigurationOperations.ReadConfiguration();
            ConfigurationOperations.SaveChanges(configuration);
            try
            {
                numbers = JsonSerializer.Deserialize<List<int>>(File.ReadAllText(configuration.ConnectionStrings.LastFile));
            }
            // TODO
            catch (FileNotFoundException ex)
            {
                //throw ex;
            }

            return numbers;
        }
    }
}
