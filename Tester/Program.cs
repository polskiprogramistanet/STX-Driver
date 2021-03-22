using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.tests;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               Console.Title = "Tester programu...";
                byte[] confrim = new byte[] { 129, 02, 00, 131 };
                byte[] state = new byte[] { 129, 2, 22, 1, 1, 6, 9, 254, 38, 0, 0, 96, 234, 150, 0, 1, 0, 210, 4, 0, 0, 0, 0, 32, 0, 165 };

                ITestMagistrala test = new TestMagistrala();
                test.SetData(confrim);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }

            Console.ReadKey();
        }
    }
}
