using System;

namespace TellDontAskKata.Main.Service
{
    public class PriceService
    {
        public static decimal RoundToTwoDigits(decimal amount)
        {
            return decimal.Round(amount, 2, MidpointRounding.ToPositiveInfinity);
        }
    }
}