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

        public BusinessService(NumberOrderingContext context, INumberSorterService numberSorterService)
        {
            _context = context;
            _numberSorterService = numberSorterService; 
        }

        public bool EndPoint1()
        {
            throw new System.NotImplementedException();
        }

        public bool EndPoint2()
        {
            throw new System.NotImplementedException();
        }

        public List<int> ImportNumberList(IFormFile file)
        {
            List<int> numbers = JsonSerializer.Deserialize<List<int>>(ConvertFileToString(file));
            /*
            foreach (var number in numbers)
            {
                _context.Numbers.Add(number);
            }
            _context.SaveChanges();
            
            List<Number> numbers = new List<Number>();
            */
            return numbers;
        }

        public List<int> ImportNumberList(List<int> numberList)
        {
            // var x = MeasurePerformance(() => BusinessService.LoadLatestFile());
            return numberList;
        }
        static private long MeasurePerformance(Action method)
        {
            Stopwatch watch = Stopwatch.StartNew();
            method();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        private string ConvertFileToString(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return reader.ReadToEnd();
            }
        }        
    }
}
