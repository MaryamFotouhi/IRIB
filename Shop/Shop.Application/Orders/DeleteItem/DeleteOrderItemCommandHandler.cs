using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.DeleteItem
{
    public class DeleteOrderItemCommandHandler : IBaseCommandHandler<DeleteOrderItemCommand>
    {
        public DeleteOrderItemCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        private readonly IOrderRepository _repository;
        public async Task<OperationResult> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.ItemId);
            if (currentOrder == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                currentOrder.DeleteItem(request.ItemId);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}