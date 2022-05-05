namespace Core.Dto.Product;

public class ProductListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public core.Entities.Products.Media.Media[] Media { get; set; }
    public Guid CategoryId { get; set; }
}