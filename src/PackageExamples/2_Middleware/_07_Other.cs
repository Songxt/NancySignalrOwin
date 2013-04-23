namespace OwinKatanaDublinAltNet
{
    using Owin;

    public class _07_Other
    {
        // Nuget package: Microsoft.Owin.Diagnostics, Microsft.Owin.Compressions

        public void Configuration(IAppBuilder builder)
        {
            builder
                .UseStaticCompression()
                .UseDiagnosticsPage("_diag");
        }
    }
}