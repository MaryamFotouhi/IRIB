using Common.Application;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountCommand:IBaseCommand
    {
        
        public long UserId { get; internal set; }
        public long ItemId { get; internal set; }
        public int Count { get; private set; }

        public IncreaseOrderItemCountCommand(long userId, long itemId, int count)
        {
            UserId = userId;
            ItemId = itemId;
            Count = count;
        }
    }
}