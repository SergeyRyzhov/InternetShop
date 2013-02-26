using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace MainSite
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            string url = "~/Error.aspx";
            Exception exc = Server.GetLastError();
            Logger.Log.Error(exc);
            //Server.ClearError();
            //return;
            
            if (exc is HttpException)
            {
                //if ((exc as HttpException).GetHttpCode() == 404)
                url = string.Format("{0}?errcode={1}&errmsg={2}", url, (exc as HttpException).GetHttpCode(), exc.Message);
            }
            else
            {
                url = string.Format("{0}?errmsg={1}", url, exc.Message);
            }

            Server.Transfer(url); 
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}