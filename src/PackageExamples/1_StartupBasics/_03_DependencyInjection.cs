namespace OwinKatanaDublinAltNet
{
    using System;
    using Microsoft.Owin.Hosting;
    using Microsoft.Owin.Hosting.Services;
    using Owin;

    public class _03_DependencyInjection
    {
        public interface IMyService
        {
            string GetFoo();
        }

        public class MyService : IMyService
        {
            public string GetFoo()
            {
                return "Bar";
            }
        }

        public class Startup
        {
            private readonly IMyService _myService;

            public Startup(IMyService myService)
            {
                _myService = myService;
            }

            public void Configuration(IAppBuilder builder)
            {
                builder.UseHandler((request, response) => response.Write(_myService.GetFoo()));
            }
        }

        public class Program
        {
            public static void Main()
            {
                IServiceProvider serviceProvider = DefaultServices
                    .Create(defaultServicesProvider => 
                        defaultServicesProvider.AddInstance<IMyService>(new MyService()));
                using (WebApplication.Start(services: serviceProvider))
                {
                    Console.ReadLine();
                }
            }
        }
    }
}