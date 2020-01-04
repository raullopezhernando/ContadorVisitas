using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ContadorVisitas.Startup))]

// LADO DEL SERVIDOR - Configuarando mapeo de Proxi con MapSignalR
namespace ContadorVisitas
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/realtime", new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
}
