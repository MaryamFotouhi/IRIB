using System.IO;
using Shop.Domain.SellerAgg;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers
{
    public static class SellerMapper
    {
        public static SellerDto? Map(this Seller? seller)
        {
            if (seller == null)
            {
                return null;
            }
            else
            {
                return new SellerDto()
                {
                    Id = seller.Id,
                    CreationDate = seller.CreationDate,
                    UserId = seller.UserId,
                    ShopName = seller.ShopName,
                    NationalCode = seller.NationalCode,
                    Status = seller.Status
                };
            }
        }
    }
}