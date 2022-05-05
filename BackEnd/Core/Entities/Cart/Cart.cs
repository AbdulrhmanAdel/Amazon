namespace core.Entities.Cart;

public class Cart
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public double TotalPrice { get; set; }
    public int Quantity { get; set; }
}