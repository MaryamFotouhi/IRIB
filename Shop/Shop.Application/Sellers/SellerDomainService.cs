using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers
{
    public class SellerDomainService: ISellerDomainService
    {
        private readonly ISellerRepository _repository;

        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public bool CheckSellerInfo(Seller seller)
        {
            var sellerIsExist = _repository.Exists(s => s.NationalCode == seller.NationalCode || s.UserId == seller.UserId);
            return !sellerIsExist;
        }

        public bool NationalCodeIsExist(string nationalCode)
        {
            return _repository.Exists(s => s.NationalCode ==nationalCode);
        }
    }
}