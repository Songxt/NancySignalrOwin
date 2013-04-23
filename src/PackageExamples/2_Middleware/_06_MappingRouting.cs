namespace OwinKatanaDublinAltNet
{
    using Microsoft.Owin.Diagnostics;
    using Owin;

    public class _06_MappingRouting
    {
        // Nuget package: Microsoft.Owin.Mapping 
      
        public void Configuration(IAppBuilder builder)
        {
            builder
                .MapPath("/api", b => b.UseHandler((request, response) => response.StatusCode = 302))
                .MapPath("/admin", b => { /* etc */})
                .MapPredicate(env => true, b => { /* etc */});
        }
    }
}