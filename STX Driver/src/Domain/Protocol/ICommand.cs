using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;


namespace STX_Driver.src.Domain.Protocol
{
    interface ICommand
    {
        CommandEnum Name { get; }
        byte[] Value { get; }

    }
}
