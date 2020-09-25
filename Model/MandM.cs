using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MandM : VendingItem
    {
        public const string Message = "Chew, Chew, Yum!";

        public MandM(
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
