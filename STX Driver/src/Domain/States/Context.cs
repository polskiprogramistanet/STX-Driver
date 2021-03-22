using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.States
{
    class Context
    {
        private IState _state = null;

        public Context(IState state)
        {
            this._state = state;
        }

        public void DoThis()
        {
            this._state.SetExecute();
        }
    }
}
