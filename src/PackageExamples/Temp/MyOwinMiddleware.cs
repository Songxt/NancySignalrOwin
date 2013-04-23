using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwinKatanaDublinAltNet
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class MyOwinMiddleware
    {
        private AppFunc _next;

        public MyOwinMiddleware(AppFunc next)
        {
            _next = next;
        }
        
        public async Task Invoke(IDictionary<string, object> environment)
        {
            string requestPath = (string)environment["owin.RequestPath"];
            //  Do something before
            await _next(environment);
            // Do something after
        }
    }
}