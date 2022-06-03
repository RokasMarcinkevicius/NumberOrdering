using Compliance.AssociatedAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NumberOrdering.Repository.Models;
using NumberOrdering.Services.Interfaces;
using System.Collections.Generic;

namespace NumberOrdering.Controllers
{
    public class NumberController : Controller
    {
        private readonly ILogger<NumberController> _logger;
        private readonly IBusinessService _businessService;
        public NumberController(ILogger<NumberController> logger, IBusinessService businessService)
        {
            _logger = logger;
            _businessService = businessService;
        }

        // TODO Add proper controller info to swagger
        // Submit a file with the number list
        [HttpPost("ImportAndOrderNumberList")]
        [ProducesResponseType(typeof(List<Number>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public List<int> ImportFileAndOrderNumberList(IFormFile file)
        {
            return _businessService.ImportNumberList(file);
        }

        // TODO Add proper controller info to swagger
        // Submit number list and a filename to which it needs to be saved to
        [HttpPost("ImportNumberLineAndOrderNumberList")]
        [ProducesResponseType(typeof(List<Number>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public List<int> ImportIntegerList(List<int> numberList, string fileName)
        {
            return _businessService.ImportNumberList(numberList, fileName);
        }

        // TODO Add proper controller info to swagger
        // Loads last file content and orders it
        [HttpGet("LoadLastFileContent")]
        [ProducesResponseType(typeof(List<Number>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public List<int> LoadLastFileContent()
        {
            return _businessService.LoadLatestFile();
        }
    }
}
