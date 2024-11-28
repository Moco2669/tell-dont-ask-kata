using System;
using TellDontAskKata.Main.Domain;

namespace TellDontAskKata.Main.Exception
{
    public class OrderShipException : ApplicationException
    {
        public OrderShipException(OrderStatus status) : base(
            "Order cannot be shipped because it's status is: " + status.ToString())
        {
            
        }
    }
}
