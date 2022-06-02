using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace NumberOrdering.Services.Interfaces
{
    public interface IBusinessService
    {
        public bool EndPoint1();
        public bool EndPoint2();
        public List<int> ImportNumberList(IFormFile file);
        public List<int> ImportNumberList(List<int> numberList);
        //public List<int> LoadLatestFile();
    }
}
