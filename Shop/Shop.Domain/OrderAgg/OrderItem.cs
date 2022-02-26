﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem:BaseEntity
    {
        private OrderItem()
        {

        }
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

        public void IncreaseCount(int count)
        {
          
            Count += count;
        }
        public void DecreaseCount(int count)
        {
            if (Count == 1)
            {
                return;
            }
            if (Count - count <= 0)
            {
                return;
            }
            Count -= count;
        }
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
        private void CountGuard(int count)
        {
            if (count < 1)
            {
                throw new InvalidDomainDataException("تعداد نامعتبر است!");
            }
        }
        private void PriceGuard(int price)
        {
            if (price < 1)
            {
                throw new InvalidDomainDataException("مبلغ نامعتبر است!");
            }
        }
    }
}