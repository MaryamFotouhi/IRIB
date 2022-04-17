using Common.Domain.Repository;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetCurrentUserOrder(long id);
    }
}