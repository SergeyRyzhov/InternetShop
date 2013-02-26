using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using MainSite.Common;
using CommonLibrary.Entities;




namespace MainSite.UserControls
{

    public class AddEventArgs : EventArgs
    {
        public int productID { get; set; }
    }

    public partial class ItemViewMini : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ImagePath
        {
            get
            {
                return ImagePreview.ImageUrl;
            }
            set
            {
                ImagePreview.ImageUrl = value;
            }
        }

        public string ItemName
        {
            get
            {
                return labelName.Text;
            }
            set
            {
                labelName.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return labelDescription.InnerHtml.Replace("<br />", "\n");
            }
            set
            {
                labelDescription.InnerHtml = value.Replace("\n", "<br />");
            }
        }

        public string Price
        {
            get
            {
                return labelPrice.Text;
            }
            set
            {
                labelPrice.Text = value;
            }
        }

        public string Count
        {
            get
            {
                return labelCount.Text;
            }
            set
            {
                labelCount.Text = value;
            }
        }

        public int productID { get; set; }

        protected void addToCard_Click(object sender, EventArgs e)
        {

            int count = 1;
            if (TextBoxCount.Text == "")
            {
                TextBoxCount.Text = "1";
                count = 1;
            }
            else
                count = Int32.Parse(TextBoxCount.Text.Trim());

            int id = productID;
            string login = Page.User.Identity.Name;

            if (login == "")
                return;

            using (CommonClient client = new CommonClient())
            {
                client.Open();

                User user = client.GetUser(login);
                Item itemProduct = client.GetItem(id);
                client.AddToCardItem(user, itemProduct, count);
                client.Close();
            }

            TextBoxCount.Text = "1";
        }



    }
}
