using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MainSite.Common;
using CommonLibrary.Entities;

namespace MainSite.Purchase
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonMakeOrder_Click(object sender, EventArgs e)
        {
            using (CommonClient client = new CommonClient())
            {
                client.Open();

                string login = Page.User.Identity.Name;

                User user = client.GetUser(login);

                client.MakeOrder(user);

                Server.Transfer("~/Shop.aspx");
                client.Close();
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}