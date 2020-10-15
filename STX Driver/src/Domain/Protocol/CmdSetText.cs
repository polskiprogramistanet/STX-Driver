using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;

namespace STX_Driver.src.Domain.Protocol
{
    class CmdSetText : ICommand
    {
        byte[] value;
        CreatorCRC crc;
        public CommandEnum Name => CommandEnum.SetText;

        public byte[] Value => value;

        public CmdSetText(int addres, FontEnum font, string text)
        {
            try
            {
               
                byte[] txt = Encoding.UTF8.GetBytes(text);
                int x = 5;
                value = new byte[x+txt.Length+1];
                value[0] = Convert.ToByte(addres);
                value[1] = 0x73;
                value[2] = (byte)(txt.Length + 1);
                value[3] = 0x00;
                value[4] = (byte)font;
                for (int i = 0; i < txt.Length; i++)
                {
                    value[x] = txt[i];
                    x++;
                }
                crc = new CreatorCRC(value);
                value[value.Length-1] = crc.Execute();

            }
            catch (Exception ex)
            {
                Console.WriteLine("CmdSetText {0}", ex.Message);
            }
        }

        
    }
}
