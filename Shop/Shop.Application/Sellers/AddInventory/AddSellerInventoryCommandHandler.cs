using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory
{
    internal class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddInventorySellerCommand>
    {
        public AddSellerInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        private readonly ISellerRepository _repository;
        public async  Task<OperationResult> Handle(AddInventorySellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);
            if (seller == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                var sellerInventory = new SellerInventory(request.SellerId, request.ProductId, request.Count, request.Count, request.DiscountPercentage);
                seller.AddInventory(sellerInventory);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}