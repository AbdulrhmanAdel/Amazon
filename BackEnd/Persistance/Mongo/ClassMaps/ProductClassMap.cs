using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto.Product;
using Core.Entities.Products;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Persistance.Mongo.ClassMaps
{
    public class ProductClassMap
    {
        public static void RegisterProductClassMap()
        {
            BsonClassMap.RegisterClassMap<Product>(product =>
            {
                product.AutoMap();
            });
            
            BsonClassMap.RegisterClassMap<ProductListDto>(product =>
            {
                product.AutoMap();
            });
        }
    }
}