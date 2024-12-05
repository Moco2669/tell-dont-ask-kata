using TellDontAskKata.Main.Service;

namespace TellDontAskKata.Main.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

        public decimal UnitaryTax => PriceService.RoundToTwoDigits((Price / 100m) * Category.TaxPercentage);
        public decimal UnitaryTaxAmount => PriceService.RoundToTwoDigits(Price + UnitaryTax);
    }
}