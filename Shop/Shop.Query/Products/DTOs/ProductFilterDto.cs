using Common.Query;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterDto : BaseDto
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Slug { get; set; }
    }
}