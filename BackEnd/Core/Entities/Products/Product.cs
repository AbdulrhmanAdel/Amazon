using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public LocalizedObject<string> Title { get; set; }
        public LocalizedObject<string> Description { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
        public core.Entities.Products.Media.Media[] Media { get; set; }
        public Guid CategoryId { get; set; }
    }
}