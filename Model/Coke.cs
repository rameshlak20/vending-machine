using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Coke : VendingItem
    {
        public const string Message = "Glug, Glug, Yum!";

        public Coke(
            string productName,
            decimal price,
            int itemsRemaining)
                : base(
                productName,
                price,
                itemsRemaining,
                Message)
        {
        }
    }
}
