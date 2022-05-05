using Core.Entities.Products;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.Constants;

namespace persistance.Seed;

public class SeedService
{
    private IMongoDatabase _mongoDatabase;

    public SeedService(IMongoClient mongoClient)
    {
        _mongoDatabase = mongoClient.GetDatabase(MongoDatabaseNames.ECommerce);
    }

    public async Task SeedAsync()
    {
        var categories = _mongoDatabase.GetCollection<Category>(MongoCollectionsNames.Categories);
        if (await categories.CountDocumentsAsync(Builders<Category>.Filter.Empty) == 0)
        {
            await categories.InsertManyAsync(CatagorySeed.GetCategories());
        }

        var products = _mongoDatabase.GetCollection<Product>(MongoCollectionsNames.Products);
        if (await products.CountDocumentsAsync(Builders<Product>.Filter.Empty) == 0)
        {
            await products.InsertManyAsync(ProductSeed.GetProducts());
        }

        await products.InsertManyAsync(ProductSeed.GetProducts());
    }
}