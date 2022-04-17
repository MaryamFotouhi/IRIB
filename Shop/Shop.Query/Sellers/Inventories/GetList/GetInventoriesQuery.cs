using System.Collections.Generic;
using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetList
{
    public class GetInventoriesQuery : IQuery<List<InventoryDto>>
    {
        public long SellerId { get; private set; }

        public GetInventoriesQuery(long sellerId)
        {
            SellerId = sellerId;
        }
    }
}

