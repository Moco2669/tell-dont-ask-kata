using System.Collections.Generic;

namespace TellDontAskKata.Main.UseCase
{
    public class SellItemsRequest
    {
        public IList<SellItemRequest> Requests { get; } = new List<SellItemRequest>();

        public void AddRequest(SellItemRequest request)
        {
            Requests.Add(request);
        }
    }
}
