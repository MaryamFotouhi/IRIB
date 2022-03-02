using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Create
{
    internal class CreateSellerCommandHandler:IBaseCommandHandler<CreateSellerCommand>
    {
        public CreateSellerCommandHandler(ISellerRepository repository, IDomainSellerService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        private readonly ISellerRepository _repository;
        private readonly IDomainSellerService _domainService;

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller=new Seller(request.UserId,request.ShopName,request.NationalCode,_domainService);
            _repository.Add(seller);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}