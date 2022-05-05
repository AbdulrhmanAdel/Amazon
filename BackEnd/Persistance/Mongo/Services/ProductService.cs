using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Common;
using Core.Common.Query;
using Core.Common.Query.Products;
using Core.Common.Results;
using Core.Dto.Category;
using Core.Dto.Product;
using Core.Entities.Products;
using Core.Identity.Services;
using Core.Interfaces;
using DefaultNamespace;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.Constants;
using Persistance.Mongo.Helpers.Aggregation;

namespace persistance.Mongo.Services
{
    public class ProductService : IProductService
    {
        private readonly ICurrentUserContext _currentUserContext;
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<BsonDocument> _products;

        public ProductService(IMongoClient mongoClient,
            ICurrentUserContext currentUserContext)
        {
            _currentUserContext = currentUserContext;
            _mongoDatabase = mongoClient.GetDatabase(MongoDatabaseNames.ECommerce);
            _products = _mongoDatabase
                .GetCollection<BsonDocument>(MongoCollectionsNames.Products);
        }

        public Task<PayloadedServiceResult<Product>> AddProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PayloadedServiceResult<PagedResult<IEnumerable<ProductListDto>>>> GetPagedListAsync(
            ProductsQueryModel query)
        {
            var pipeline = new List<BsonDocument>()
                .AddMatchStage(BuildGetProductFilter(query));

            var count = await _products.GetDocumentCountsAsync(pipeline);

            pipeline = pipeline.AddSortStage(query)
                .AddProjectStage(new BsonDocument()
                {
                    { "description", "$description.en" },
                    { "title", "$title.en" },
                    { "price", 1 },
                    { "quantityInStock", 1 },
                    { "media", 1 },
                    { "categoryId", 1 }
                });


            var q = pipeline.Build<BsonDocument, ProductListDto>();
            using var productsCursor = await _products.AggregateAsync(pipeline.Build<BsonDocument, ProductListDto>());
            return new PayloadedServiceResult<PagedResult<IEnumerable<ProductListDto>>>()
            {
                Payload = new PagedResult<IEnumerable<ProductListDto>>(
                    await productsCursor.ToListAsync()
                    , count)
            };
        }

        public async Task<IEnumerable<CategoryListDto>> GetCategoriesAsync()
        {
            var categoriesCollection = _mongoDatabase.GetCollection<BsonDocument>(MongoCollectionsNames.Categories);

            var pipeline = new List<BsonDocument>()
                .AddProjectStage(new BsonDocument()
                {
                    { "name", "$name.en" }
                });

            using var categoriesCursor =
                await categoriesCollection.AggregateAsync(pipeline.Build<BsonDocument, CategoryListDto>());
            return await categoriesCursor.ToListAsync();
        }

        private BsonDocument BuildGetProductFilter(ProductsQueryModel queryModel)
        {
            var match = new BsonDocument();
                match.AddRange(new BsonDocument("price", new BsonDocument("$in", new BsonArray()
                {
                    queryModel.FromPrice,
                    queryModel.ToPrice
                })));
            // if (queryModel.ToPrice.HasValue)
            // {
            // }
            // else
            // {
            //     match.AddRange(new BsonDocument("price", new BsonDocument("$gte", queryModel.FromPrice)));
            // }

            return match;
        }
    }
}