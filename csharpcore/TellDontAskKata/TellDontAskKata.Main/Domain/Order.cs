using System.Collections.Generic;

namespace TellDontAskKata.Main.Domain
{
    public class Order
    {
        public decimal Total { get; set; }
        public string Currency { get; }
        public IList<OrderItem> Items { get; }
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

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
            Tax += item.Tax;
            Total += item.TaxedAmount;
        }

        public void Approve(bool approved)
        {
            if (Status == OrderStatus.Created)
            {
                Status = approved ? OrderStatus.Approved : OrderStatus.Rejected;
            }
        }

        public void Ship()
        {
            if (Status == OrderStatus.Approved)
            {
                Status = OrderStatus.Shipped;
            }
        }
    }
}
