using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class OrderHandler
    {
        private readonly VendingMachine _vm;

        public OrderHandler(VendingMachine vm)
        {
            _vm = vm;
        }

        public string GetOrderMessage(string[] orderParams)
        {

            if (orderParams.Length != 4)
            {
                return "Invalid Parameters";
            }

            var orderObj = this.ConstructOrder(orderParams);
            if (orderObj.Item1 != string.Empty)
            {
                return orderObj.Item1;
            }
            else
            {
                return this.ProcessOrder(orderObj.Item2);
            }
        }

        private string ProcessOrder(Order order)
        {
            VendingItem vendingItem;
            if (_vm.VendingMachineItems.TryGetValue(order.ItemNo, out vendingItem))
            {
                if (vendingItem.ItemsRemaining < order.Quantity)
                {
                    return "Entered quanity is greater than Inventory. Unable to fulfill order";
                }

                decimal total = order.Quantity * vendingItem.Price;
                if (total == order.Amount)
                {
                    return "Success..Order is full filled.";
                }
                else
                {
                    return "Failed..Exact change is required.";
                }
            }
            else
            {
                return "Invalid Item No is entered";
            }
        }

        private Tuple<string, Order> ConstructOrder(string[] orderParams)
        {
            StringBuilder errorMessage = new StringBuilder();
            decimal amount;
            int  quantity;
            Order order = new Order();
            order.ItemNo = orderParams[2];
            if (decimal.TryParse(orderParams[1], out amount))
            {
                order.Amount = amount;
            }
            else
            {
                errorMessage.AppendLine("Incorret Amount is entered");
            }

            if (int.TryParse(orderParams[3], out quantity))
            {
                order.Quantity = quantity;
            }
            else
            {
                errorMessage.AppendLine("Incorret Quantity is entered");
            }

            return Tuple.Create(errorMessage.ToString(), order);
        }
    }
}
