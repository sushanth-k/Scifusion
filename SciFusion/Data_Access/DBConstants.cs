using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Data_Access
{
    public static class DBConstants
    {
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    }
}