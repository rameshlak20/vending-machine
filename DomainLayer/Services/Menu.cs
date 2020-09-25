using DomainLayer.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Services
{
    public class Menu :IMenu
    {
        private readonly IVendingMachine _vm;
        private readonly IOrderService _orderService;

        public Menu(IVendingMachine vm, IOrderService orderService)
        {
            _vm = vm;
            _orderService = orderService;
        }

        public async void Display()
        {
            PrintHeader();
            while (true)
            {
                Console.WriteLine();
                _vm.DisplayItems();
                Console.WriteLine("");
                Console.WriteLine("**********************");
                Console.WriteLine("");

                Console.WriteLine("Main Menu");
                Console.WriteLine("inv] Inventory");
                Console.WriteLine("order <amount> <item-number> <quantity>] Order");
                Console.WriteLine("Q] Quit");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "inv")
                {
                    _vm.Inventory();
                }
                else if (input.StartsWith("order"))
                {
                    string[] orderParams = input.Split(' ');
                    var result = await _orderService.ProcessOrder(orderParams);
                    Console.WriteLine(result);

                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE BEST VENDING MACHINE EVER!!!! (Distant crowd roar)");
        }

    }
}
