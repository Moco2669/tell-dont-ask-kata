namespace TellDontAskKata.Main.UseCase
{
    public class SellItemRequest
    {
        public int Quantity { get; }
        public string ProductName { get; }

        public SellItemRequest(string productName, int quantity)
        {
            Quantity = quantity;
            ProductName = productName;
        }
    }
}
