using Owin;

namespace KatanaConsoleApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseTestPage();
        }
    }
}
