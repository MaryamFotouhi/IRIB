using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory:BaseEntity
    {
        private SellerInventory()
        {

        }
        public SellerInventory(long sellerId, long productId, int count, int price)
        {
            if (count < 0)
            {
                throw new InvalidDomainDataException("تعداد نامعتبر است!");
            }
            if (price < 1)
            {
                throw new InvalidDomainDataException("مبلغ نامعتبر است!");
            }
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
        }

        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
    }
}