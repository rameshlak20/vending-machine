using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Candy : VendingItem
    {
        public const string Message = "Chew, Chew, Yum!";

        public Candy(
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
