using Common.Application;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Application.Sellers.Edit
{
    public class EditSellerCommand:IBaseCommand
    {
        public EditSellerCommand(long id, string shopName, string nationalCode, SellerStatus status)
        {
            Id = id;
            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
        }

        public long Id { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
    }
}