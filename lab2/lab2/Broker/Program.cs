using Services;
using System;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Broker is running!");

            IService broker = new BrokerService();

            Task t = Task.Factory.StartNew(async () =>
            {
                string message;

                while ((message = await broker.AsyncRead()) != "quit b")
                {
                    Console.WriteLine(message);
                    await broker.AsyncWrite(message);
                    await broker.AsyncReload();
                }
            });

            t.Wait();

            Console.ReadLine();
        }
    }
}
