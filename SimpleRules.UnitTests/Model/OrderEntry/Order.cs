using System.Collections.Generic;
using System;
using System.Linq;

namespace SimpleRules.UnitTests.Model.OrderEntry
{
    public class Order
    {
        public string Number { get; set; }

        public List<OrderItem> Items { get; set; }

        public OrderStatus Status { get; set; }

        public Order()
        {
            Status = OrderStatus.New;
            Items = new List<OrderItem>();
        }

        public bool ContainsItem(Func<OrderItem, bool> condition)
        {
            return Items.Any(condition);
        }

        public decimal SumItemsBy(Func<OrderItem, bool> condition)
        {
            return Items.Where(condition).Sum(i => i.Quantity);
        }
    }
}
