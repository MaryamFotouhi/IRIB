#nullable enable
using Common.Query;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetByUserId
{
    public class GetSellerByUserIdQuery : IQuery<SellerDto?>
    {
        public long UserId { get; private set; }

        public GetSellerByUserIdQuery(long userId)
        {
            UserId = userId;
        }
    }
}
