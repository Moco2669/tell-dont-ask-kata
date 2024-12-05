using TellDontAskKata.Main.Service;
using TellDontAskKata.Main.UseCase;

namespace TellDontAskKata.Main.Domain
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TaxedAmount { get; set; }
        public decimal Tax { get; set; }

        public OrderItem(Product product, SellItemRequest itemRequest)
        {
            Product = product;
            Quantity = itemRequest.Quantity;
            Tax = PriceService.RoundToTwoDigits(product.UnitaryTax * itemRequest.Quantity);
            TaxedAmount = PriceService.RoundToTwoDigits(product.UnitaryTaxAmount * itemRequest.Quantity);
        }
    }
}
