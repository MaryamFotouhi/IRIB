using Common.Domain.Repository;
using Shop.Domain.CategoryAgg;

namespace Shop.Domain.UserAgg.Repository
{
    public interface IUserRepository:IBaseRepository<User>
    {
        UserAddress GetAddressById(long addressId);
    }
}