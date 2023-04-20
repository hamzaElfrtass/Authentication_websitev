using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Authentication_websitev
{
    /// <summary>
    /// Description résumée de Myservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class Myservice : System.Web.Services.WebService
    {

        public AuthUser User;
        [WebMethod]
        [SoapHeader("User", Required = true)]
        public string helloworld()
        {
            if (User != null)

            {
                if (User.Isvalid())
                {
                    return "Heloo" + User.UserName;
                }
                else
                    return "Invalid User details!";
            }
            else
                return "please provide User details";
        }
    }
}
