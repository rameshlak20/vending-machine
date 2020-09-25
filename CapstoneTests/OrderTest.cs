using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public  void TestIfOrderSuccess()
        {
            FileHandler fileHandler = new FileHandler();

            Dictionary<string, VendingItem> items = fileHandler.GetVendingItems();
            VendingItem item = new Chip("Zapp's Voodoo Chip", 3.05M, 5);
            VendingMachine vm = new VendingMachine();
            OrderHandler orderHandler = new OrderHandler(vm);
            string[] orderParams = { "order", "12.2", "A1", "4" };
            string result = orderHandler.GetOrderMessage(orderParams);

            Assert.AreEqual("Success..Order is full filled.", result);
        }

        [TestMethod]
        public  void TestIfOrderFails()
        {
            FileHandler fileHandler = new FileHandler();

            Dictionary<string, VendingItem> items = fileHandler.GetVendingItems();
            VendingItem item = new Chip("Zapp's Voodoo Chip", 3.05M, 5);
            VendingMachine vm = new VendingMachine();
            OrderHandler orderHandler = new OrderHandler(vm);
            string[] orderParams = { "order", "12.2", "A1", "7" };
            string result = orderHandler.GetOrderMessage(orderParams);

            Assert.AreEqual("Entered quanity is greater than Inventory. Unable to fulfill order", result);
        }


        [TestMethod]
        public void TestIfOrderFailsWithInvalidParameters()
        {
            FileHandler fileHandler = new FileHandler();

            Dictionary<string, VendingItem> items = fileHandler.GetVendingItems();
            VendingItem item = new Chip("Zapp's Voodoo Chip", 3.05M, 5);
            VendingMachine vm = new VendingMachine();
            OrderHandler orderHandler = new OrderHandler(vm);
            string[] orderParams = { "order", "12.2", "A1", "7","SD" };
            string result = orderHandler.GetOrderMessage(orderParams);

            Assert.AreEqual("Invalid Parameters", result);
        }
    }
}
