using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Contract
{
    public interface ILoggerService
    {
        void Log(string message, decimal moneyBefore, decimal moneyAfter);
    }
}
