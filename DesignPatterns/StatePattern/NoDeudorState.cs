using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StatePattern
{
    public class NoDeudorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine($"Action en el NoDeudorState. Amount is {amount}");
            if (amount <= customerContext.Residue)
            {
                customerContext.Discount(amount);
                Console.WriteLine($"Allowed request, spend {amount} and residue");
                if (customerContext.Residue <= 0)
                {
                    customerContext.SetState(new DeudorState());
                }
            }
            else
            {
                Console.WriteLine($"amount {amount} is not allowed because amount is greater or equal to residue of {customerContext.Residue}");
            }
        }
    }
}
