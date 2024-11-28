using System;
using TellDontAskKata.Main.Domain;

namespace TellDontAskKata.Main.Exception
{
    public class WrongOrderStatusOnApproveException : ApplicationException
    {
        public WrongOrderStatusOnApproveException(OrderStatus status, bool approve) : base(
            "Order approval status can not be changed because it's in status: " + status.ToString())
        {
            
        }
    }
}