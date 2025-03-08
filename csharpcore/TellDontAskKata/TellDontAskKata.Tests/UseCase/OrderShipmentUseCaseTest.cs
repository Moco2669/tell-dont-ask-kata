using System;
using TellDontAskKata.Main.Domain;
using TellDontAskKata.Main.UseCase;
using TellDontAskKata.Tests.Doubles;
using TellDontAskKata.Main.Exception;
using Xunit;

namespace TellDontAskKata.Tests.UseCase
{
    public class OrderShipmentUseCaseTest
    {
        private const int AnOrderId = 1;
        private readonly TestOrderRepository _orderRepository;
        private readonly TestShipmentService _shipmentService;
        private readonly OrderShipmentUseCase _useCase;

        public OrderShipmentUseCaseTest()
        {
            _orderRepository = new TestOrderRepository();
            _shipmentService = new TestShipmentService();
            _useCase = new OrderShipmentUseCase(_orderRepository, _shipmentService);
        }


        [Fact]
        public void ShipApprovedOrder()
        {
            var initialOrder = AnOrderWith(AnOrderId);
            initialOrder.Approve(true);
            
            _orderRepository.AddOrder(initialOrder);

            var request = AnOrderShipmentRequestWithOrderIdMatching(initialOrder);

            _useCase.Run(request);

            Assert.Equal(OrderStatus.Shipped, _orderRepository.GetSavedOrder().Status);
            Assert.Same(initialOrder, _shipmentService.GetShippedOrder());
        }

        private static OrderShipmentRequest AnOrderShipmentRequestWithOrderIdMatching(Order initialOrder)
        {
            return new OrderShipmentRequest
            {
                OrderId = initialOrder.Id
            };
        }

        private static Order AnOrderWith(int anOrderId)
        {
            return new Order(anOrderId);
        }

        [Fact]
        public void CreatedOrdersCannotBeShipped()
        {
            var initialOrder = new Order
            {
                Id = 1
            };
            _orderRepository.AddOrder(initialOrder);

            var request = new OrderShipmentRequest
            {
                OrderId = 1
            };

            Action actionToTest = () => _useCase.Run(request);

            Assert.Throws<OrderShipException>(actionToTest);
            Assert.Null(_orderRepository.GetSavedOrder());
            Assert.Null(_shipmentService.GetShippedOrder());
        }

        [Fact]
        public void RejectedOrdersCannotBeShipped()
        {
            var initialOrder = new Order
            {
                Id = 1
            };
            initialOrder.Approve(false);
            _orderRepository.AddOrder(initialOrder);

            var request = new OrderShipmentRequest
            {
                OrderId = 1
            };

            Action actionToTest = () => _useCase.Run(request);

            Assert.Throws<OrderShipException>(actionToTest);
            Assert.Null(_orderRepository.GetSavedOrder());
            Assert.Null(_shipmentService.GetShippedOrder());
        }

        [Fact]
        public void ShippedOrdersCannotBeShippedAgain()
        {
            var initialOrder = new Order
            {
                Id = 1
            };
            initialOrder.Approve(true);
            initialOrder.Ship();
            _orderRepository.AddOrder(initialOrder);

            var request = new OrderShipmentRequest
            {
                OrderId = 1
            };

            Action actionToTest = () => _useCase.Run(request);

            Assert.Throws<OrderShipException>(actionToTest);
            Assert.Null(_orderRepository.GetSavedOrder());
            Assert.Null(_shipmentService.GetShippedOrder());
        }


    }
}
