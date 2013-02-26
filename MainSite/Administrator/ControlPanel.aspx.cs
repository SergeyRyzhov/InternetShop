using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MainSite.Common;
using CommonLibrary.Entities;

namespace MainSite
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            string login = CreateUserWizard1.UserName;
            string email = CreateUserWizard1.Email;

            using (CommonClient client = new CommonClient())
            {
                client.Open();
                client.AddUser(new User() { Name = login, Email = email });
                client.Close();
            }

        }
    }
}