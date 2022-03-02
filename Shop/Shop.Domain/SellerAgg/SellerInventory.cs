using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        private SellerInventory()
        {

        }
        public SellerInventory(long sellerId, long productId, int count, int price, int? discountPercentage = null)
        {
            Guard(count, price);
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }

        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }

        public void Edit(int count, int price, int? discountPercentage = null)
        {
            Guard(count, price);
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }

        private void Guard(int count, int price)
        {
            if (count < 0)
            {
                throw new InvalidDomainDataException("تعداد نامعتبر است!");
            }
            if (price < 1)
            {
                throw new InvalidDomainDataException("مبلغ نامعتبر است!");
            }
        }
    }
}