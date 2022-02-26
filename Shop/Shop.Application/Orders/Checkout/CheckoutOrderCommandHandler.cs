using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.Checkout
{
    public class CheckoutOrderCommandHandler:IBaseCommandHandler<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        private readonly IOrderRepository _repository;
        public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
            {
                return  OperationResult.NotFound();
            }
            else
            {
                var address = new OrderAddress(request.Shire,request.City,request.PostalCode,request.PostalAddress,
                    request.PhoneNumber,request.Name,request.Family,request.NationalCode);
                currentOrder.Checkout(address);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}