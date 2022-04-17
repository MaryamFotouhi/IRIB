using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetById
{
    public class GetProductByIdQuery : IQuery<ProductDto?>
    {
        public GetProductByIdQuery(long productId)
        {
            ProductId = productId;
        }

        public long ProductId { get; private set; }
    }
}

