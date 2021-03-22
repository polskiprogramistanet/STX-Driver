using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using STX_Driver.src.Domain.Observers;

namespace STX_Driver.src.Domain.Entities
{
    class TimeOut
    {
        int tiktak = 0;
        int seconds = 10;
        
        bool breaker = false;
        readonly IObserverTimeOutOperation observer = null;

        public TimeOut(IObserverTimeOutOperation observer)
        {
            this.observer = observer;
        }

        public void Starter(int seconds)
        {
            this.seconds = seconds;
            Console.WriteLine("Time out on");
            this.tiktak = 0;
            Thread thread = new Thread(Engine);
            thread.Start();
        }

        public void Break()
        {
            breaker = true;
        }

        void Engine()
        {
            while (this.tiktak < seconds && breaker == false)
            {
                this.tiktak++;
                
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
            this.observer.FinishedTimeOut();
        }
    }
}
