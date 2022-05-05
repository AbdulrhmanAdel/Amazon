using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Common.Query
{
    public class BaseQueryModel : PagedModel
    {
        public string SearchTerm { get; set; }
    }
}