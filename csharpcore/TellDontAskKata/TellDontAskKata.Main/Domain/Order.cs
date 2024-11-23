using System.Collections.Generic;

namespace TellDontAskKata.Main.Domain
{
    public class Order
    {
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Tax { get; set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        public Order()
        {
            Status = OrderStatus.Created;
            Tax = 0m;
            Total = 0m;
            Currency = "EUR";
            Items = new List<OrderItem>();
        }

        public void AddItems(OrderItem item)
        {
            Items.Add(item);
            Tax += item.Tax;
            Total += item.TaxedAmount;
        }
    }
}
