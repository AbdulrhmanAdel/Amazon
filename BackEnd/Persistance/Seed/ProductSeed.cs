using Core.Entities.Products;
using core.Entities.Products.Media;
using Core.Entities.Products.Media;
using core.Helpers;

namespace persistance.Seed;

public static class ProductSeed
{
    public static IEnumerable<Product> GetProducts()
    {
        var randomNumberGenerator = new Random();
        return Enumerable.Range(0, 50).Select((_, i) => new Product()
        {
            Id = Guid.NewGuid(),
            Title = new LocalizedObject<string>() { En = $"Product {i}" }.PopulateNullableLanguages(),
            Description = new LocalizedObject<string>() { En = $"Product Description {i}" }.PopulateNullableLanguages(),
            QuantityInStock = i,
            Price = i * randomNumberGenerator.Next(0, 10000),
            CategoryId = CatagorySeed.CategoryIds.GetRandomCatagory(),
            Media = new[]
            {
                new Media()
                {
                    Id = Guid.NewGuid(), Url = $"https://localhost:5001/products/{i}.jpg", Type = MediaType.Image,
                    IsMain = true
                },
                new Media()
                {
                    Id = Guid.NewGuid(), Url = $"https://localhost:5001/products/{i * 2}.jpg", Type = MediaType.Image,
                    IsMain = false
                },
            }
        });
    }

    public static Guid GetRandomCatagory(this List<Guid> source)
    {
        var randomNumberGenerator = new Random();
        var count = randomNumberGenerator.Next(0, source.Count);

        return source[count];
    }
}