using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Authentication_websitev
{
    public class AuthUser : System.Web.Services.Protocols.SoapHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Isvalid()
        {
            int count = 0;
            string config = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection sqlcon = new SqlConnection(config))
            {
                SqlCommand sqlcmd = new SqlCommand("select * from tblAuthUser where UserName='" + UserName + "' and Password='" + Password + "'");
                sqlcmd.Connection.Open();
                count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                sqlcmd.Connection.Close();
                if (count > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}