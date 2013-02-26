using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MainSite
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["errcode"];
            string msg = Request.QueryString["errmsg"];
            if (code != "")
                labelErrorCode.Text = string.Format("Код ошибки - {0}", code);
            if (msg != "")
                labelErrorMessage.Text = msg;//string.Format("{0}", msg);
        }
    }
}