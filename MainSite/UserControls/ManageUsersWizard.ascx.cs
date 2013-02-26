using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

using MainSite.Common;
using CommonLibrary.Entities;




namespace MainSite.UserControls
{
    public partial class ManageUsersWizard : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User[] users;
            using (CommonClient client = new CommonClient())
            {
                client.Open();

                users = client.GetUsers();
                client.Close();
            }
            if (users != null)
                TableRowsUsersCreate(users);
        }

        private void TableRowsUsersCreate(User[] users)
        {


            for (int i = 0; i < users.Count(); i++)
            {
                TableRow tr = new TableRow();
                tr.Cells.Add(new TableCell() { Text = users[i].ID.ToString() });
                tr.Cells.Add(new TableCell() { Text = users[i].Name.ToString() });
                tr.Cells.Add(new TableCell() { Text = users[i].Email.ToString() });



                Button btnDel = new Button();
                btnDel.Click += new EventHandler(btnDel_Click);
                btnDel.CssClass = "btn btn-danger";
                btnDel.Text = "Удалить";



                HiddenField hideLogin = new HiddenField();
                hideLogin.Value = users[i].Name.ToString();

                TableCell tc = new TableCell();
                tc.Controls.Add(btnDel);
                tc.Controls.Add(hideLogin);
                tr.Cells.Add(tc);


                Table1.Rows.Add(tr);
            }
        }

        void btnDel_Click(object sender, EventArgs e)
        {
            TableCell tr = ((sender as Button).Parent as TableCell);

            string login = "";
            foreach (var item in tr.Controls)
            {
                if (item is HiddenField)
                    login = (item as HiddenField).Value;
            }
            if (login != "")
            {
                using (CommonClient client = new CommonClient())
                {
                    client.Open();
                    User user = client.GetUser(login);
                    client.RemoveUser(user);
                    client.Close();
                }
                Membership.DeleteUser(login);
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}