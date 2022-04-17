using Common.Application;

namespace Shop.Application.Orders.DeleteOrderItem
{
    public class DeleteOrderItemCommand:IBaseCommand
    {
        public long UserId { get; internal set; }
        public long ItemId { get; internal set; }

        public DeleteOrderItemCommand(long userId, long itemId)
        {
            UserId = userId;
            ItemId = itemId;
        }
    }
}