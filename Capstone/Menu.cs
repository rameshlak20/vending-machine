namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Menu
    {
        private readonly VendingMachine _vm;
        private readonly OrderHandler _orderHdl;

        public Menu(VendingMachine vm, OrderHandler orderHdl)
        {
            _vm = vm;
            _orderHdl = orderHdl;
        }

        public void Display()
        {
            PrintHeader();
            while (true)
            {
                Console.WriteLine();
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
                    var result = _orderHdl.GetOrderMessage(orderParams);
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

        private  void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE BEST VENDING MACHINE EVER!!!! (Distant crowd roar)");
        }

    }
}
