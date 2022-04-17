using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.EF.ProductAgg
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}