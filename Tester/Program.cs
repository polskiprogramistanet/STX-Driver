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
                Console.Title = "Tester programu";

                //TestCardsOperations test = new TestCardsOperations();
                //test.TestLoadCards();

                TestProtocol prot = new TestProtocol();
                prot.TestSetText();
                //byte[] ba = Encoding.Default.GetBytes("sample");
                //Console.WriteLine(ba);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }

            Console.ReadKey();
        }
    }
}
