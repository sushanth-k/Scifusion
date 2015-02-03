using MySql.Data.MySqlClient;
using SciFusion.Data_Access;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SciFusion
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //ProvisionDatabase();                     
        }
        
        /// <summary>
        /// Provision Database Class to create initial set of data.
        /// </summary>
        public void ProvisionDatabase()
        {      
            MySqlConnection connection = new MySqlConnection("server=localhost;Uid=root;Pwd=5588;");
            connection.Open();
            FileInfo file = new FileInfo(Server.MapPath("~/SQLScript/SciFusionStartup.sql"));
            string myTestSql = file.OpenText().ReadToEnd();
            string script = myTestSql.Replace("GO", "");
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = myTestSql;
            command.ExecuteNonQuery();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["LoginStatus"] = "Log In";
            Session["ResearcherId"] = 2;
        }

    }
}