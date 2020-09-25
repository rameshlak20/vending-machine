using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Contract
{
    public interface IFileHandler
    {
         Dictionary<string, VendingItem> GetVendingItems();
    }
}
