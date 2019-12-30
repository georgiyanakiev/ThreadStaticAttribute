using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AdvancedTasks
{
    public static class Program
    {
        public static int counter;
        public static ThreadLocal<int> local =
            new ThreadLocal<int>(() =>
              {
                  return Thread.CurrentThread.ManagedThreadId;
              });
        public static void Main()
        {
            new Thread(() =>
            {
                for ( int x = 0; x<local.Value; x++)
                {
                    counter++;
                    Console.WriteLine("Thread 1: {0}", x);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < local.Value; x++)
                {
                    counter++;
                    Console.WriteLine("Thread 2: {0}", x);
                }
            }).Start();
            //bool stop = false;
            //Thread t = new Thread(new ThreadStart(() =>

            //{
            //    while (!stop)
            //    {
            //        Console.WriteLine("Thread is running...");
            //        Thread.Sleep(2000);
            //    }

            //}));
            ////t.IsBackground = true;
            //t.Start();
            //t.Join();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            //stop = true;


            //t.Join();

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("This is main Thread!");
            //    Thread.Sleep(0);
            //}
            //t.Join();
            //Console.ReadLine();
        }
    }
}
