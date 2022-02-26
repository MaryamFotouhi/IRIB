using Common.Application;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseOrderItemCountCommand : IBaseCommand
    {
        public DecreaseOrderItemCountCommand(long userId, long itemId, int count)
        {
            UserId = userId;
            ItemId = itemId;
            Count = count;
        }

        public long UserId { get; internal set; }
        public long ItemId { get; internal set; }
        public int Count { get; private set; }
    }
}