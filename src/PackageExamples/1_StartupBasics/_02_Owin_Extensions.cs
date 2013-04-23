namespace OwinKatanaDublinAltNet
{
    using Owin;

    public class _02_Owin_Extensions
    {
        // Nuget package: Owin.Extensions
        public class Startup1
        {
            public void Configuration(IAppBuilder builder)
            {
                builder.UseHandlerAsync((request, response) => response.WriteAsync("Sup"));
            }
        }

        public class Startup2
        {
            public void Configuration(IAppBuilder builder)
            {
                builder.UseHandler((request, response) =>
                                       {
                                           // write headers first!
                                           response.StatusCode = 200; 
                                           response.Write("Sup");
                                       });
            }
        }
    }
}