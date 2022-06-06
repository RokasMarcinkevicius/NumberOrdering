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

        /// <summary>
        /// Imports your selected file, orders the number list and returns it
        /// </summary>
        /// <response code="200">Import successful, number list ordered. </response>
        /// <response code="400">Imported list has invalid values. </response>
        /// <response code="500">Oops! Can't import file/order list right now. </response> 
        [HttpPost("ImportAndOrderNumberList")]
        [ProducesResponseType(typeof(List<int>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public List<int> ImportFileAndOrderNumberList(IFormFile file)
        {
            return _businessService.ImportNumberList(file);
        }

        /// <summary>
        /// Submit number list and a filename to which it needs to be saved to, return it ordered.
        /// </summary>
        /// <response code="200">Import successful, number list ordered. </response>
        /// <response code="400">Imported list has invalid values. </response>
        /// <response code="500">Oops! Can't order list right now. </response> 
        [HttpPost("ImportNumberLineAndOrderNumberList")]
        [ProducesResponseType(typeof(List<int>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public List<int> ImportIntegerList(List<int> numberList, string fileName)
        {
            return _businessService.ImportNumberList(numberList, fileName);
        }

        /// <summary>
        /// Loads last file.
        /// </summary>
        /// <response code="200">File loading successful. </response>
        /// <response code="400">File not found. </response>
        /// <response code="500">Oops! Can't load file right now. </response> 
        [HttpGet("LoadLastFileContent")]
        [ProducesResponseType(typeof(List<int>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public List<int> LoadLastFileContent()
        {
            return _businessService.LoadLatestFile();
        }
    }
}
