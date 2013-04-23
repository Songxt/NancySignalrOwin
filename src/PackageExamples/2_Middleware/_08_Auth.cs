namespace OwinKatanaDublinAltNet
{
    using System.Threading.Tasks;
    using Owin;

    public class _08_Auth
    {
        // Nuget package: Microsoft.Owin.Auth.Basic

        public class Startup
        {
            public void Configuration(IAppBuilder builder)
            {
                builder.UseBasicAuth((username, password) => Task.FromResult(false));
            }
        }
    }
}