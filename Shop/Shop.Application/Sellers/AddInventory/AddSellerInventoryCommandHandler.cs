using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory
{
    internal class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddSellerInventoryCommand>
    {
        private readonly ISellerRepository _repository;

        public AddSellerInventoryCommandHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();

            var sellerInventory = new SellerInventory(request.SellerId, request.ProductId, request.Count, request.Count, request.DiscountPercentage);
            seller.AddInventory(sellerInventory);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}