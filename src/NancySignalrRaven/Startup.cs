namespace SampleApp
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Diagnostics;
    using Owin;
    using Raven.Client;

    public class Startup
    {
        private readonly IDocumentStore _documentStore;

        public Startup(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Configuration(IAppBuilder builder)
        {
            // Configure SignalR DI
            GlobalHost.DependencyResolver.Register(typeof (IDocumentStore), () => _documentStore);

            // Nancy DI container is configured in its bootstrapper
            var sampleBootstrapper = new SampleBootstrapper(_documentStore);

            // Note: it's perfectly viable to have an over-arching single application container
            // and configure signalr and nancy to use it.

            builder
                .MapPath("/fault",
                         faultBuilder => faultBuilder
                            .UseErrorPage(new ErrorPageOptions { ShowExceptionDetails = true })
                            .UseHandler((request, response) => { throw new Exception("oops!"); }))
                .MapPath("/files",
                         siteBuilder => siteBuilder
                            .UseBasicAuth((user, pass) => Task.FromResult(pass == "damo"))
                            .UseDenyAnonymous()
                            .UseDirectoryBrowser(@"c:\"))
                .MapPath("/scripts", scriptsBuilder => scriptsBuilder.UseFileServer("scripts"))
                .MapPath("/site", siteBuilder => siteBuilder.UseNancy(cfg => cfg.Bootstrapper = sampleBootstrapper))
                .MapSignalR()
                .UseWelcomePage();
        }
    }
}