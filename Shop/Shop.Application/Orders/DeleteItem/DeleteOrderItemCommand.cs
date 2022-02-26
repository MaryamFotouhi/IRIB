using Common.Application;

namespace Shop.Application.Orders.DeleteItem
{
    public class DeleteOrderItemCommand:IBaseCommand
    {
        public DeleteOrderItemCommand(long userId, long itemId)
        {
            UserId = userId;
            ItemId = itemId;
        }

        public long UserId { get; internal set; }
        public long ItemId { get; internal set; }
    }
}