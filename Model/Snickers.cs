using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

    public class Snickers : VendingItem
    {
        public const string Message = "Chew, Chew, Yum!";

        public Snickers(
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
