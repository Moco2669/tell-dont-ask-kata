using TellDontAskKata.Main.Domain;
using TellDontAskKata.Main.Repository;
using TellDontAskKata.Main.Exception;

namespace TellDontAskKata.Main.UseCase
{
    public class OrderCreationUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductCatalog _productCatalog;

        public OrderCreationUseCase(
            IOrderRepository orderRepository,
            IProductCatalog productCatalog)
        {
            _orderRepository = orderRepository;
            _productCatalog = productCatalog;
        }

        public void Run(SellItemsRequest request)
        {
            var order = new Order();

            foreach(var itemRequest in request.Requests)
            {
                var product = _productCatalog.GetByName(itemRequest.ProductName);
                order.AddItem(new OrderItem(product, itemRequest));
            }

            _orderRepository.Save(order);
        }
    }
}
