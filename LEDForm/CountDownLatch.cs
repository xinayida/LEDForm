using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LEDForm
{
    class CountDownLatch
    {
        private object lockObj = new Object();
        private int counter;
        private int oriCounter;

        public CountDownLatch(int counter)
        {
            this.counter = counter;
            this.oriCounter = counter;
        }

        public void Await()
        {
            lock (lockObj)
            {
                while (counter > 0)
                {
                    Monitor.Wait(lockObj);
                }
            }
        }

        public void CountDown()
        {
            lock (lockObj)
            {
                counter--;
                Monitor.PulseAll(lockObj);
            }
        }

        public void reset()
        {
            counter = oriCounter;
        }
    }
}
