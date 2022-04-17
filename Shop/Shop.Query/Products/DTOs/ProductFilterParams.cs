using Common.Query.Filter;

namespace Shop.Query.Products.DTOs
{
    public class ProductFilterParams : BaseFilterParam
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}