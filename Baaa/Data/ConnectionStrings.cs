using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Baaa.Data
{
    public class ConnectionStrings
    {
        public static string Baaa
        {   //connection string for Baaa Database
            get { return ConfigurationManager.ConnectionStrings["BaaaDatabase"].ConnectionString; }
        }
    }
}