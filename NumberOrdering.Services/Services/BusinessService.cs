using Microsoft.AspNetCore.Http;
using NumberOrdering.Repository.Data;
using NumberOrdering.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace NumberOrdering.Services.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly NumberOrderingContext _context;
        private readonly INumberSorterService _numberSorterService;
        private readonly IFileService _fileService;

        public BusinessService(NumberOrderingContext context, INumberSorterService numberSorterService, IFileService fileService)
        {
            _context = context;
            _numberSorterService = numberSorterService; 
            _fileService = fileService;
        }

        public List<int> ImportNumberList(IFormFile file)
        {
            return JsonSerializer.Deserialize<List<int>>(_fileService.ConvertFileToString(file));
        }

        public List<int> ImportNumberList(List<int> numberList, string fileName)
        {
            // TODO add measures to information loggers
            MeasurePerformance(() => _numberSorterService.BubbleSort(numberList));
            MeasurePerformance(() => _numberSorterService.CountingSort(numberList));
            MeasurePerformance(() => _numberSorterService.MergeSort(numberList));
            MeasurePerformance(() => _numberSorterService.QuickSort(numberList));

            numberList = _numberSorterService.BubbleSort(numberList);             

            _fileService.SaveToFile(numberList, fileName);
            
            return numberList;
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
