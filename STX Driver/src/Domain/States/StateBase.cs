using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Domain.States
{
    abstract class StateBase
    {
        protected Context _context;
        public void SetContext(Context context)
        {
            this._context = context;
        }


    }
}
