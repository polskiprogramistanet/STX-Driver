using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STX_Driver.src.Application;

namespace STX_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IInitOperation init = new Initiation("com1", "Data Source=192.168.1.5\\INSERTGT;Initial Catalog=BudTrans2012;Persist Security Info=True;User ID=sa;Password=junak");
                init.GetReaderData += Init_GetReaderData;
                init.StartEngine();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static void Init_GetReaderData(object sender, object e)
        {
           
        }
    }
}
