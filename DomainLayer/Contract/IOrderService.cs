using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contract
{
    public interface IOrderService
    {
        Task <string> ProcessOrder(string[] orderParams);
        Task<string> CalculateOrderTotal(Order order);
    }
}
