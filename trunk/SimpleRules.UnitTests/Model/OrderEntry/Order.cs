using System.Collections.Generic;
using System;
using System.Linq;

namespace SimpleRules.UnitTests.Model.OrderEntry
{
    public partial class Order
    {
        public string Number { get; set; }

        public List<OrderItem> Items { get; set; }

        public OrderStatus Status { get; set; }

        public Order()
        {
            Status = OrderStatus.New;
            Items = new List<OrderItem>();
        }

        public bool ContainsItem(Func<OrderItem, bool> match)
        {
            return Items.Any(match);
        }

        public decimal SumItemQuantityWhere(Func<OrderItem, bool> match)
        {
            return Items.Where(match).Sum(i => i.Quantity);
        }
    }
}
