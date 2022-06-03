using Microsoft.AspNetCore.Http;
using NumberOrdering.Repository.Models;
using NumberOrdering.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NumberOrdering.Services.Services
{
    public class FileService : IFileService
    {
        public bool SaveToFile(string fileName, List<int> numbers)
        {
            try
            {
                File.WriteAllText(fileName, JsonSerializer.Serialize<List<int>>(numbers));
                return true;
            }
            // TODO add logger here
            catch (Exception)
            {
                return false;
            }
        }

        public List<int> LoadLatestFile(string fileName = null)
        {
            // TODO add logger here
            if(fileName == null)
            {
                var configuration = ConfigurationOperations.ReadConfiguration();
                ConfigurationOperations.SaveChanges(configuration);

                return JsonSerializer.Deserialize<List<int>>(File.ReadAllText(configuration.ConnectionStrings.LastFile));
            }
            else
            {
                return JsonSerializer.Deserialize<List<int>>(File.ReadAllText(fileName));
            }
        }

        public string ConvertFileToString(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return reader.ReadToEnd();
            }
        }  
    }
}
