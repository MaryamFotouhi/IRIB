using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem:BaseEntity
    {
        public OrderItem(long inventoryId, int count, int price)
        {
            CountGuard(count);
            PriceGuard(price);
            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long OrderId { get; internal set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Count * Price;

        public void ChangeCount(int newCount)
        {
            CountGuard(newCount);
            Count = newCount;
        }
        public void SetPrice(int newPrice)
        {
            PriceGuard(newPrice);
            Price = newPrice;
        }
        public void CountGuard(int count)
        {
            if (count < 1)
            {
                throw new InvalidDomainDataException("تعداد نامعتبر است!");
            }
        }
        public void PriceGuard(int price)
        {
            if (price < 1)
            {
                throw new InvalidDomainDataException("مبلغ نامعتبر است!");
            }
        }
    }
}