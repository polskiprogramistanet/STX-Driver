using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;

namespace STX_Driver.src.Domain.Protocol
{
    class CmdStatus : ICommand
    {
        byte[] value = new byte[5];
        CreatorCRC crc;
        public CommandEnum Name =>  CommandEnum.Status;
        public byte[] Value => value;

        public CmdStatus(int adress)
        {
            value[0] = Convert.ToByte(adress);    //address
            value[1] = 0x02;                      //status
            value[2] = 0x01;                      //data count
            value[3] = 0x00;
            crc = new CreatorCRC(value);
            value[4] = crc.Execute();    
        }
    }
}
