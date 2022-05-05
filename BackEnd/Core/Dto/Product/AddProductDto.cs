using Core.Entities.Products;
using core.Entities.Products.Media;

namespace core.Dto.Product;

public class AddProductDto
{
    public LocalizedObject<string> Name { get; set; }
    public LocalizedObject<string> Description { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public Guid CategoryId { get; set; }
    public Media[] Media { get; set; }
}