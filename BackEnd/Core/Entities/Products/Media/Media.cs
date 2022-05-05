using Core.Entities.Products.Media;

namespace core.Entities.Products.Media
{
    public class Media
    {
        public Guid Id { get; set; }
        public MediaType Type { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsMain { get; set; }
    }
}