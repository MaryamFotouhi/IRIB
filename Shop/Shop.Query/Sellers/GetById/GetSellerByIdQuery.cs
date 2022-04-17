#nullable enable
using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById
{
    public class GetSellerByIdQuery:IQuery<SellerDto?>
    {
        public GetSellerByIdQuery(long sellerId)
        {
            SellerId = sellerId;
        }

        public long SellerId { get; private set; }
    }
}