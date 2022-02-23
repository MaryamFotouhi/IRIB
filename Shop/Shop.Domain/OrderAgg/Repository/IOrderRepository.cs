using System.Threading.Tasks;
using Common.Domain.Repository;
using Shop.Domain.CategoryAgg;

namespace Shop.Domain.OrderAgg.Repository
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        Task<Order> GetCurrentUserOrder(long id);
    }
}