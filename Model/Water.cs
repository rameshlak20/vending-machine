using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Water : VendingItem
    {
        public const string Message = "Glug, Glug, Yum!";

        public Water(
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
