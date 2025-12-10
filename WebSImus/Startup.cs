using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebSImus.Startup))]

namespace WebSImus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app) => ConfigureAuth(app);
    }
}
