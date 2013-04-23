namespace OwinKatanaDublinAltNet
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Owin;
    using Owin.Types;

    public class _09_CustomMiddleware
    {
        public class Startup
        {
            public void Configuration(IAppBuilder builder)
            {
                builder.MapPath("/admin", adminBuilder => adminBuilder
                                            .DenyNonLocalRequests()
                                            .UseHandler((request, response) => response.Write("You're in.")));
            }
        }

        public class DenyNonLocalRequestsMiddleware
        {
            private readonly Func<IDictionary<string, object>, Task> _next;

            public DenyNonLocalRequestsMiddleware(Func<IDictionary<string, object>, Task> next)
            {
                _next = next;
            }

            public Task Invoke(IDictionary<string, object> env)
            {
                var request = new OwinRequest(env);
                var response = new OwinResponse(env);
                if (!request.IsLocal)
                {
                    response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                    return Task.FromResult(0);
                }
                return _next(env);
            }
        }
    }

    public static class OwinExtensions
    {
        public static IAppBuilder DenyNonLocalRequests(this IAppBuilder appBuilder)
        {
            return appBuilder.UseType<_09_CustomMiddleware.DenyNonLocalRequestsMiddleware>();
        }
    }
}