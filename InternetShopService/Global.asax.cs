using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using InternetShopService.Core;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace InternetShopService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Logger.Log.Info(string.Format("Application started from {0}", sender));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Logger.Log.Info(string.Format("Session started from {0}", sender));
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            Logger.Log.Info(exc);
            Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Logger.Log.Info(string.Format("Session stopped from {0}", sender));
        }

        protected void Application_End(object sender, EventArgs e)
        {

            Logger.Log.Info(string.Format("Application stopped from {0}", sender));
        }
    }
}