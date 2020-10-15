using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STX_Driver.src.Application
{
    public interface IInitOperation
    {
        event EventHandler<object> GetReaderData;
        
        void StartEngine();
        void StopEngine();


    }
}
