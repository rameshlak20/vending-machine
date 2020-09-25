using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using Capstone;
using DomainLayer.Services;
using Model;

namespace CapstoneTests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public   void TestIfOrderSuccess()
        {
            FileHandler fileHandler = new FileHandler();

            Dictionary<string, VendingItem> items = fileHandler.GetVendingItems();
            VendingItem item = new Water("Zapp's Voodoo Water", 3.05M, 5);
            VendingMachine vm = new VendingMachine();
            OrderService orderHandler = new OrderService(vm);
            string[] orderParams = { "order", "6.25", "1", "5"};
            string result =  orderHandler.ProcessOrder(orderParams).GetAwaiter().GetResult();

            Assert.AreEqual("Success..Order is full filled.", result);
        }

        [TestMethod]
        public  void TestIfOrderFails()
        {
            FileHandler fileHandler = new FileHandler();

            Dictionary<string, VendingItem> items = fileHandler.GetVendingItems();
            VendingItem item = new Water("Zapp's Voodoo Water", 3.05M, 5);
            VendingMachine vm = new VendingMachine();
            OrderService orderHandler = new OrderService(vm);
            string[] orderParams = { "order", "6.25", "1", "15" };
            string result =  orderHandler.ProcessOrder(orderParams).GetAwaiter().GetResult();

            Assert.AreEqual("Entered quanity is greater than Inventory. Unable to fulfill order", result);
        }


        [TestMethod]
        public  void TestIfOrderFailsWithInvalidParameters()
        {
            FileHandler fileHandler = new FileHandler();

            Dictionary<string, VendingItem> items = fileHandler.GetVendingItems();
            VendingItem item = new Water("Zapp's Voodoo Water", 3.05M, 5);
            VendingMachine vm = new VendingMachine();
            OrderService orderHandler = new OrderService(vm);
            string[] orderParams = { "order", "6.25", "1", "5","SD" };
            string result =  orderHandler.ProcessOrder(orderParams).GetAwaiter().GetResult();

            Assert.AreEqual("Invalid Parameters", result);
        }
    }
}
