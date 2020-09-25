using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Contract
{
    public interface IMoney
    {
         bool AddMoney(string amount);
         bool RemoveMoney(decimal amountToRemove);
         string GiveChange();
    }
}
