using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById
{
    public class GetCategoryByIdQuery:IQuery<CategoryDto?>
    {
        public long CategoryId { get; private set; }

        public GetCategoryByIdQuery(long categoryId)
        {
            CategoryId = categoryId;
        }
    }
}