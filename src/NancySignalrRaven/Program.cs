namespace SampleApp
{
    using System;
    using Microsoft.Owin.Hosting;
    using Microsoft.Owin.Hosting.Services;
    using Raven.Client;
    using Raven.Client.Embedded;

    internal class Program
    {
        private static void Main(string[] args)
        {
            using (IDocumentStore documentStore = new EmbeddableDocumentStore {RunInMemory = true}.Initialize())
            {
                IServiceProvider serviceProvider = DefaultServices.Create(p => p.AddInstance<IDocumentStore>(documentStore));
                using (WebApplication.Start<Startup>(serviceProvider, 2020))
                {
                    Console.WriteLine("Started on port 2020");
                    Console.ReadKey();
                    Console.WriteLine("Stopping");
                }
            }
        }
    }
}