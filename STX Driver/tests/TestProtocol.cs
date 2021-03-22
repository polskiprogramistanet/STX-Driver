using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Common.Enums;
using libProtocols.STX.Commands;
using libProtocols.STX.Common;

namespace STX_Driver.tests
{
    public class TestProtocol : ITestProtocol
    {
        public void TestStatus()
        {
            I_STXCommand status = new STXCmdStatus(1, STXStatusEnum.Status);
            Console.WriteLine("Name {0}", status.Name.ToString());
            Console.Write("Data {0}", BitConverter.ToString(status.Value));

        }
        
        public void TestSetText()
        {
            I_STXCommand setText = new STXCmdSetText(1, STXFontEnum.Arial_Black_16, "Dupa");
            Console.WriteLine("Name {0}", setText.Name.ToString());
            Console.Write("Data {0}", BitConverter.ToString(setText.Value));

            //byte[] ba = Encoding.Default.GetBytes("sample");
            //Console.WriteLine(ba);
        }

      
    }
}
