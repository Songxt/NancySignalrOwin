using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwinKatanaDublinAltNet
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class MyOwinApp
    {
        public Task Invoke(IDictionary<string, object> environment)
        {
            string requestPath = (string)environment["owin.RequestPath"];
            //...etc
            return Task.FromResult(0);
        }
    }
}