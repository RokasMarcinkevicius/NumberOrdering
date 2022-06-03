using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace NumberOrdering.Services.Interfaces
{
    public interface IBusinessService
    {
        public List<int> ImportNumberList(IFormFile file);
        public List<int> ImportNumberList(List<int> numberList, string fileName);
    }
}
