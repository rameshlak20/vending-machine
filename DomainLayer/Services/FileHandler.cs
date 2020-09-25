using DomainLayer.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DomainLayer.Services
{
    public class FileHandler :IFileHandler
    {
        private const int Pos_itemNumber = 0;
        private const int Pos_ItemName = 1;
        private const int Pos_ItemPrice = 2;
        private const int Pos_itemType = 4;
        private const int Pos_itemQty = 3;


        public Dictionary<string, VendingItem> GetVendingItems()
        {
            Dictionary<string, VendingItem> items = new Dictionary<string, VendingItem>();

            string file = string.Empty;
            if (File.Exists("vendingmachine.csv"))
            {
                file = "vendingmachine.csv";

                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (!sr.EndOfStream)
                        {
                            // Read the line
                            string line = sr.ReadLine();

                            string[] itemDetails = line.Split("|");

                            string itemName = itemDetails[Pos_ItemName];

                            if (!decimal.TryParse(itemDetails[Pos_ItemPrice], out decimal itemPrice))
                            {
                                itemPrice = 0M;
                            }

                            if (!int.TryParse(itemDetails[Pos_itemQty], out int itemQty))
                            {
                                itemQty = 0;
                            }

                            VendingItem item;

                            switch (itemDetails[Pos_ItemName])
                            {
                                case "Coke":
                                    item = new Coke(itemName, itemPrice, itemQty);
                                    break;
                                case "Water":
                                    item = new Water(itemName, itemPrice, itemQty);
                                    break;
                                case "Snickers":
                                    item = new Snickers(itemName, itemPrice, itemQty);
                                    break;
                                default:
                                    item = new MandM(itemName, itemPrice, itemQty);
                                    break;
                            }

                            items.Add(itemDetails[Pos_itemNumber], item);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error trying to open the input file.");
                }
            }
            else
            {
                Console.WriteLine("Input file is missing!! The vending machine will now self destruct.");
                items.Add("A1", new Water("YOU BROKE IT!", 10000M, 5));
            }

            return items;
        }
    }
}
