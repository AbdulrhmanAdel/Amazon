using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Common.Results
{
    public class PagedResult<T>
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }

        public PagedResult(T data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }
    }
}