namespace Core.Entities.Products;

public class Category
{
    public Guid Id { get; set; }
    public LocalizedObject<string> Name { get; set; }
}