using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        private Order()
        {

        }
        public Order(long userId, OrderStatus status)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public OrderAddress? Address { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(i => i.TotalPrice);
                if (ShippingMethod != null)
                {
                    totalPrice += ShippingMethod.ShippingCost;
                }
                if (Discount != null)
                {
                    totalPrice -= Discount.DiscountAmount;
                }
                return totalPrice;
            }
        }

        public void AddItem(OrderItem item)
        {
            item.OrderId = Id;
            Items.Add(item);
        }
        public void DeleteItem(long itemId)
        {
            var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
            if (currentItem == null)
            {
                throw new NullOrEmptyDomainDataException("Item Not Found");
            }
            Items.Remove(currentItem);
        }
        public void ChangeCountItem(long itemId,int newCount)
        {
            var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
            if (currentItem == null)
            {
                throw new NullOrEmptyDomainDataException("Item Not Found");
            }
            currentItem.ChangeCount(newCount);
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate=DateTime.Now;
        }
        public void Checkout(OrderAddress address)
        {
            Address = address;
        }
    }
}