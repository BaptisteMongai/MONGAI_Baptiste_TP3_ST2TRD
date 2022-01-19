using System;
using System.Threading;

namespace TP_3
{
    public class Exercice2
    {
        Mutex mutex = new Mutex();

        public void Run(int time, int frequency, string message)
        {
            int tour = time * 1000 / frequency;

            while(tour != 0)
            {
                mutex.WaitOne();
                Console.Write(message);
                mutex.ReleaseMutex();
                Thread.Sleep(frequency);
                tour--;
            }
        }
    }
}