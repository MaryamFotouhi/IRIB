using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Edit
{
    internal class EditSellerCommandHandler:IBaseCommandHandler<EditSellerCommand>
    {
        public EditSellerCommandHandler(ISellerRepository repository, IDomainSellerService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        private readonly ISellerRepository _repository;
        private readonly IDomainSellerService _domainService;
        public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
        {
            var seller =await _repository.GetTracking(request.Id);
            if (seller == null)
            {
                return OperationResult.NotFound();
            }
            else
            {
                seller.Edit(request.ShopName,request.NationalCode,request.Status,_domainService);
                await _repository.Save();
                return OperationResult.Success();
            }
        }
    }
}