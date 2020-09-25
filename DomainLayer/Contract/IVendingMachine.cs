using DomainLayer.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Contract
{
    public interface IVendingMachine
    {
         void DisplayAllItems();
         void Inventory();
         bool ItemExists(string itemNumber);
         bool RetreiveItem(string itemNumber);
         decimal MoneyInMachine { get; }
         Money Money { get; }
        Dictionary<string, VendingItem> VendingMachineItems { get; set; }
        string NotEnoughMoneyError { get;  set; }
        string MessageToUser { get; set; }
        void DisplayItems();
    }
}
