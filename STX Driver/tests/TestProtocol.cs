using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Domain.Protocol;
using STX_Driver.src.Common.Enums;

namespace STX_Driver.tests
{
    public class TestProtocol
    {
        public void TestStatus()
        {
            ICommand status = new CmdStatus(1);
            Console.WriteLine("Name {0}", status.Name.ToString());
            Console.Write("Data {0}", BitConverter.ToString(status.Value));

        }
        
        public void TestSetText()
        {
            ICommand setText = new CmdSetText(1, FontEnum.Arial_Black_16, "Dupa");
            Console.WriteLine("Name {0}", setText.Name.ToString());
            Console.Write("Data {0}", BitConverter.ToString(setText.Value));

            //byte[] ba = Encoding.Default.GetBytes("sample");
            //Console.WriteLine(ba);
        }
    }
}
