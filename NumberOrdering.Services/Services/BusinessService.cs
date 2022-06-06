using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NumberOrdering.Repository.Data;
using NumberOrdering.Repository.Interfaces;
using NumberOrdering.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace NumberOrdering.Services.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly NumberOrderingContext _context;
        private readonly INumberSorterService _numberSorterService;
        private readonly IFileService _fileService;
        private readonly ILogger<BusinessService> _logger;

        public BusinessService(NumberOrderingContext context, INumberSorterService numberSorterService, IFileService fileService, ILogger<BusinessService> logger)
        {
            _context = context;
            _numberSorterService = numberSorterService; 
            _fileService = fileService;
            _logger = logger;
        }

        public List<int> ImportNumberList(IFormFile file)
        {
            List<int> numberList = JsonSerializer.Deserialize<List<int>>(_fileService.ConvertFileToString(file));
            ExecutePerformanceMeasurements(numberList);

            return _numberSorterService.BubbleSort(numberList);
        }

        public List<int> ImportNumberList(List<int> numberList, string fileName)
        {
            ExecutePerformanceMeasurements(numberList);

            numberList = _numberSorterService.BubbleSort(numberList);             
            _fileService.SaveToFile(numberList, fileName);
            
            return numberList;
        }

        // Passthrough
        public List<int> LoadLatestFile()
        {
            return _fileService.LoadLatestFile();
        }

        private bool ExecutePerformanceMeasurements(List<int> numberList)
        {
            // TODO Display logged information to end user
            try
            {
                _logger.LogInformation("Bubble Sort completed sorting in " + MeasurePerformance(() => _numberSorterService.BubbleSort(numberList)) + "ms");
                _logger.LogInformation("Counting Sort completed sorting in " + MeasurePerformance(() => _numberSorterService.CountingSort(numberList)) + "ms");
                _logger.LogInformation("Merge Sort completed sorting in " + MeasurePerformance(() => _numberSorterService.MergeSort(numberList)) + "ms");
                _logger.LogInformation("Quick Sort completed sorting in " + MeasurePerformance(() => _numberSorterService.QuickSort(numberList)) + "ms");
                return true;
            }
            catch
            {
                return false;
            }
        }

        static private long MeasurePerformance(Action method)
        {
            Stopwatch watch = Stopwatch.StartNew();
            method();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
