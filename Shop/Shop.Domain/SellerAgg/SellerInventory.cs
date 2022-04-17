using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }

        private SellerInventory()
        {

        }

        public SellerInventory(long sellerId, long productId, int count, int price, int? discountPercentage = null)
        {
            Guard(count, price, discountPercentage);
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }

        public void Edit(int count, int price, int? discountPercentage = null)
        {
            Guard(count, price, discountPercentage);
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }

        private void Guard(int count, int price, int? discountPercentage = null)
        {
            if (count < 0)
                throw new InvalidDomainDataException("تعداد نامعتبر است!");
            
            if (price < 1)
                throw new InvalidDomainDataException("مبلغ نامعتبر است!");

            if (discountPercentage!=null && discountPercentage < 1)
                throw new InvalidDomainDataException("مبلغ تخفیف نامعتبر است!");
        }
    }
}