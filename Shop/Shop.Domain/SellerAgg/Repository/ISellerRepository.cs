using System.Threading.Tasks;
using Common.Domain.Repository;
using Shop.Domain.CategoryAgg;

namespace Shop.Domain.SellerAgg.Repository
{
    public interface ISellerRepository:IBaseRepository<Seller>
    {
        Task<SellerInventoryResult> GetInventoryById(long id);
    }

    public class SellerInventoryResult
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}