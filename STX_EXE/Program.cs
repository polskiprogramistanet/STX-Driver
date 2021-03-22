using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using STX_Driver.src.Application;
using libProtocols.OilSocket.Common;

namespace STX_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OilDriver driver = new OilDriver();
                               
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
    }

    class OilDriver
    {
        ISTXOperation stx = null;
        public OilDriver()
        {
            stx = new STXEngine("com1", "Data Source=192.168.1.5\\DARTSYSTEM;Initial Catalog=CTL_GROUP;Persist Security Info=True;User ID=sa;Password=junak");
            stx.StartEngine();
        }

        
    }
}
