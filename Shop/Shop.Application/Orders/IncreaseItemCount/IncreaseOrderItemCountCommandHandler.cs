using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountCommandHandler:IBaseCommandHandler<IncreaseOrderItemCountCommand>
    {
        public IncreaseOrderItemCountCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        private readonly IOrderRepository _repository;
        public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                currentOrder.IncreaseItemCount(request.ItemId,request.Count);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}