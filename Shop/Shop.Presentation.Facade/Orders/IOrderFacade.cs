using Common.Application;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Query.Orders.DTOs;
using System.Threading.Tasks;
using Shop.Application.Orders.AddOrderItem;
using Shop.Application.Orders.DeleteOrderItem;

namespace Shop.Presentation.Facade.Orders
{
    public interface IOrderFacade
    {
        Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
        Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command);
        Task<OperationResult> DeleteOrderItem(DeleteOrderItemCommand command);
        Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
        Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);


        Task<OrderDto?> GetOrderById(long orderId);
        Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams);
    }
}

