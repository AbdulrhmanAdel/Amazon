using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Common
{
    public class ServiceResult
    {
        public bool Success => Messages.Count == 0;

        public IList<string> Messages { get; set; } = new List<string>();

        public void AddError(string errorMessage)
        {
            Messages.Add(errorMessage);
        }
    }
}