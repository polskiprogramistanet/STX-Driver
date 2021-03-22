using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


namespace STX_Driver.src.Domain.States
{
    class CardActive : IState
    {
        
        public CardActive(string code)
        {
           // cardOperation = new RepositoryOfCard(code);
        }

        public void SetExecute()
        {
            
        }
    }
}
