using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using log4net.Config;

namespace mywebservice
{

    public class Log
    {
        static Log()
        {
            XmlConfigurator.Configure();
        }

        public static ILog For(object LoggedObject)
        {
            if (LoggedObject != null)
                return For(LoggedObject.GetType());
            else
                return For(null);
        }

        public static ILog For(Type ObjectType)
        {
            if (ObjectType != null)
                return LogManager.GetLogger(ObjectType.Name);
            else
                return LogManager.GetLogger(string.Empty);
        }
    }


    /// <summary>
    /// Description résumée de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
    }
}
