using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Products
{
    public class LocalizedObject<T>
    {
        public T En { get; set; }
        public T Ar { get; set; }
    }
}