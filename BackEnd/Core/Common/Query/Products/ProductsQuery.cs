namespace Core.Common.Query.Products
{
    public class ProductsQueryModel : BaseQueryModel
    {
        public double FromPrice { get; set; }
        public double ToPrice { get; set; } = double.MaxValue;
    }
}