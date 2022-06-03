using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<FileService> _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }
        
        public bool SaveToFile(List<int> numbers, string fileName)
        {
            try
            {
                File.WriteAllText(fileName, JsonSerializer.Serialize<List<int>>(numbers));
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Saving to file failed");
                return false;
            }
        }

        public List<int> LoadLatestFile(string fileName = null)
        {
            try
            {
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
            catch (Exception exception)
            {
                _logger.LogError(exception, "File loading failed");
                return null;
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
