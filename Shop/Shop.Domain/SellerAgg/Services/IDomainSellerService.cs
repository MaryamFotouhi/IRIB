namespace Shop.Domain.SellerAgg.Services
{
    public interface IDomainSellerService
    {
        bool CheckSellerInfo(Seller seller);
        bool NationalCodeIsExist(string nationalCode);
    }
}