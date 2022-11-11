using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IServicesTest
    {
        IEnumerable<TestModel> GetMessage();
    }
}