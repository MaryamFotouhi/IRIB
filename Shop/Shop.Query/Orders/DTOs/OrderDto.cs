#nullable enable
using System;
using System.Collections.Generic;
using Common.Query;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Query.Orders.DTOs
{
    public class OrderDto: BaseDto
    {
        public long UserId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? LastUpdate { get; set; }
        public OrderAddress? Address { get; set; }
        public ShippingMethod? ShippingMethod { get; set; }
        public OrderDiscount? Discount { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public string UserFullName { get; set; }
        public string ShopName { get; set; }
    }
}