using System;
using System.Collections.Generic;
using System.Text;

namespace CoopSoftNetCore.Core.Implementations
{
    public interface ISampleService
    {
        string GetCurrentDate();
    }

    public class SampleService : ISampleService
    {
        public string GetCurrentDate()
        {
            return DateTime.Now.ToLongDateString();
        }
    }
}
