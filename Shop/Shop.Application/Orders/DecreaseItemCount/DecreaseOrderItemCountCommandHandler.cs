using Common.Application;
using Shop.Domain.OrderAgg.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseOrderItemCountCommandHandler : IBaseCommandHandler<DecreaseOrderItemCountCommand>
    {
        public DecreaseOrderItemCountCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        private readonly IOrderRepository _repository;
        public async Task<OperationResult> Handle(DecreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                currentOrder.DecreaseItemCount(request.ItemId, request.Count);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}