#nullable enable
using Common.Query;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetById
{
    public class GetSellerInventoryByIdQuery : IQuery<InventoryDto?>
    {
        public long InventoryId { get; private set; }

        public GetSellerInventoryByIdQuery(long inventoryId)
        {
            InventoryId = inventoryId;
        }
    }
}

