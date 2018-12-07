using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(HangFireMvcServer.Startup))]

namespace HangFireMvcServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(@"Server = PC774\SQLEXPRESS2; Database = HangFire; Integrated Security = True;");
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
