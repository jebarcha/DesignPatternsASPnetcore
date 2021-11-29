using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StatePattern
{
    public class NewState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine($"Add amount {amount}");
            customerContext.Residue = amount;
            customerContext.SetState(new NoDeudorState());
        }
    }
}
