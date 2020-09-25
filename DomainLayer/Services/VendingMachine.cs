﻿using DomainLayer.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Services
{
    public class VendingMachine :IVendingMachine
    {
        private LoggerService Log = new LoggerService();
        public Dictionary<string, VendingItem> VendingMachineItems = new Dictionary<string, VendingItem>();
        FileHandler HandleFiles = new FileHandler();
        public Money Money { get; }
        public string NotEnoughMoneyError = "Not enough money in the machine to complete the transaction.";
        public string MessageToUser;

        public VendingMachine()
        {
            this.VendingMachineItems = this.HandleFiles.GetVendingItems();
            this.Money = new Money(this.Log);

        }

        public decimal MoneyInMachine
        {
            get
            {
                return this.Money.MoneyInMachine;
            }
        }

        Dictionary<string, VendingItem> IVendingMachine.VendingMachineItems { 
            get {
                return VendingMachineItems;
            } 
            set {
                VendingMachineItems = value;
            }
        }

        string IVendingMachine.NotEnoughMoneyError { 
            get { 
                return NotEnoughMoneyError; 
            }
            set {
                NotEnoughMoneyError = value;
            } 
        }

        string IVendingMachine.MessageToUser { 
            get {
                return MessageToUser;
            } set {
                MessageToUser = value;
            } 
        }

        public void DisplayAllItems()
        {
            Console.WriteLine($"\n\n{"#".PadRight(5)} {"Stock"} { "Product".PadRight(47) } { "Price".PadLeft(7)}");
            foreach (KeyValuePair<string, VendingItem> kvp in this.VendingMachineItems)
            {
                if (kvp.Value.ItemsRemaining > 0)
                {
                    string itemNumber = kvp.Key.PadRight(5);
                    string itemsRemaining = kvp.Value.ItemsRemaining.ToString().PadRight(5);
                    string productName = kvp.Value.ProductName.PadRight(40);
                    string price = kvp.Value.Price.ToString("C").PadLeft(7);
                    Console.WriteLine($"{itemNumber} {itemsRemaining} {productName} Costs: {price} each");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.ProductName} IS SOLD OUT.");
                }
            }
        }


        public void DisplayItems()
        {
            
            foreach (KeyValuePair<string, VendingItem> kvp in this.VendingMachineItems)
            {
                if (kvp.Value.ItemsRemaining > 0)
                {
                    string itemNumber = kvp.Key.PadRight(5);
                    string itemsRemaining = kvp.Value.ItemsRemaining.ToString();
                    string productName = kvp.Value.ProductName;
                    string price = kvp.Value.Price.ToString("C");
                    Console.WriteLine($"{productName}:Quantity={itemsRemaining}; Price={price}");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.ProductName} IS SOLD OUT.");
                }
            }
        }

        public void Inventory()
        {
            var index = 1;
            foreach (KeyValuePair<string, VendingItem> kvp in this.VendingMachineItems)
            {
                if (kvp.Value.ItemsRemaining > 0)
                {
                    string itemNumber = kvp.Key.PadRight(5);
                    string itemsRemaining = kvp.Value.ItemsRemaining.ToString();
                    string productName = kvp.Value.ProductName;
                    string price = kvp.Value.Price.ToString("C");
                    Console.WriteLine($"{index.ToString()} {productName} ({itemsRemaining}):{price}");
                    index++;
                }
                else
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.ProductName} IS SOLD OUT.");
                }
            }
        }

        public bool ItemExists(string itemNumber)
        {
            return this.VendingMachineItems.ContainsKey(itemNumber);
        }

        public bool RetreiveItem(string itemNumber)
        {
            // If the item exists (not Q1 or something like that)
            // and we can remove the item
            // and we have more money in the machine than the price
            if (this.ItemExists(itemNumber)
                && this.Money.MoneyInMachine >= this.VendingMachineItems[itemNumber].Price
                && this.VendingMachineItems[itemNumber].ItemsRemaining > 0
                && this.VendingMachineItems[itemNumber].RemoveItem())
            {
                // Logging message "CANDYBARNAME A1"
                string message = $"{this.VendingMachineItems[itemNumber].ProductName.ToUpper()} {itemNumber}";

                // Logging before: current money in machine
                decimal before = this.Money.MoneyInMachine;

                // Remove the money
                this.Money.RemoveMoney(this.VendingMachineItems[itemNumber].Price);

                // Logging after: current money in machine
                decimal after = this.Money.MoneyInMachine;

                // Log the log
                this.Log.Log(message, before, after);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
