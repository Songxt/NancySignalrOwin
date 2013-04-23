using Owin;

namespace KatanaWebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseTestPage();
        }
    }
}
