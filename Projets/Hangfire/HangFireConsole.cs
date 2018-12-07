// PM> Install-Package Hangfire
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Owin;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace MyHangfire
{
    class HangFireConsole
    {
        //public SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PayrollDB;Persist Security Info=True;Integrated Security=true;");

        static void Main(string[] args)
        {
            var s = new SqlConnection(@"Server = PC774\SQLEXPRESS2; Database = csi3; Integrated Security = True;");
            s.Open();

        }
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("<connection string or its name>");
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
