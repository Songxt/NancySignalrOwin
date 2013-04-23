namespace KatanaConsoleApplication1
{
    using System;
    using Microsoft.Owin.Hosting;

    internal class Program
    {
        private static void Main(string[] args)
        {
            using (WebApplication.Start())
            {
                Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }

            // Can explictly specify Startup class
            using (WebApplication.Start<Startup>(port: 81))
            {}
        }
    }
}