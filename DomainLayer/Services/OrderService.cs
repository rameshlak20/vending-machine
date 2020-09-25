using DomainLayer.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IVendingMachine _vm;

        public OrderService(IVendingMachine vm)
        {
            _vm = vm;
        }

        public async Task<string> ProcessOrder(string[] orderParams)
        {
            string result = string.Empty;

            if (orderParams.Length != 4)
            {
                result = "Invalid Parameters";
            }
            else {
                var orderObj = this.ConstructOrder(orderParams);
                if (orderObj.Item1 != string.Empty)
                {
                    result = orderObj.Item1;
                }
                else
                {
                    result = await CalculateOrderTotal(orderObj.Item2);
                }
            }
            return result;
        }


        public  Task<string> CalculateOrderTotal(Order order)
        {
            string result = string.Empty;
            VendingItem vendingItem;
            if (_vm.VendingMachineItems.TryGetValue(order.ItemNo, out vendingItem))
            {
                if (vendingItem.ItemsRemaining < order.Quantity)
                {
                    result = "Entered quanity is greater than Inventory. Unable to fulfill order";
                }
                else
                {
                    decimal total = order.Quantity * vendingItem.Price;
                    if (total == order.Amount)
                    {
                        result = "Success..Order is full filled.";
                    }
                    else
                    {
                        result = "Failed..Exact change is required.";
                    }
                }

            }
            else
            {
                result =  "Invalid Item No is entered";
            }
            return Task.FromResult(result);
        }

        private Tuple<string, Order> ConstructOrder(string[] orderParams)
        {
            StringBuilder errorMessage = new StringBuilder();
            decimal amount;
            int quantity;
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
