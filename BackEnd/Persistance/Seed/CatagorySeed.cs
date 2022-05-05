using Core.Entities.Products;
using core.Helpers;

namespace persistance.Seed;

public class CatagorySeed
{
    public static List<Guid> CategoryIds = new List<Guid>()
    {
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE1"),
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE2"),
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE3"),
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE4"),
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE5"),
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE6"),
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE7"),
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE8"),
        new Guid("49EE7B8F-89EF-4176-BDCE-4E068F9D6DE9"),
        
    };
    public static IEnumerable<Category> GetCategories()
    {
        return CategoryIds.Select((id, i) => new Category()
        {
            Id = id,
            Name = new LocalizedObject<string>() { En = $"Category {i}" }.PopulateNullableLanguages()
        });
    }
}