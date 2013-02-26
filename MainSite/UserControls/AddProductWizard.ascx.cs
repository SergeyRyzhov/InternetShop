using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MainSite.Common;
using CommonLibrary.Entities;




namespace MainSite.UserControls
{
    public partial class AddProductWizard : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            bool result = false;
            if (args is CommandEventArgs)
            {
                CommandEventArgs commandEventArgs = (CommandEventArgs)args;
                if (string.Equals(commandEventArgs.CommandName, "AddProduct", StringComparison.OrdinalIgnoreCase))
                {
                    AddProduct();
                    result = true;
                }

                if (string.Equals(commandEventArgs.CommandName, "ClearForm", StringComparison.OrdinalIgnoreCase))
                {
                    ClearFields();
                    result &= true;
                }
                if (string.Equals(commandEventArgs.CommandName, "UploadPicture", StringComparison.OrdinalIgnoreCase))
                {
                    UploadPicture();
                    result &= true;
                }
            }
            result &= base.OnBubbleEvent(source, args);

            return result;
        }

        public string ImagePath
        {
            get
            {
                return imageMiniView.ImageUrl;
            }
            set
            {
                imageMiniView.ImageUrl = value;
            }
        }

        public string ItemName
        {
            get
            {
                return textBoxName.Text;
            }
            set
            {
                textBoxName.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return textBoxDescription.Text;
            }
            set
            {
                textBoxDescription.Text = value;
            }
        }

        public string Price
        {
            get
            {
                return textBoxPrice.Text;
            }
            set
            {
                textBoxPrice.Text = value;
            }
        }

        public string Count
        {
            get
            {
                return textBoxCount.Text;
            }
            set
            {
                textBoxCount.Text = value;
            }
        }

        public int productID { get; set; }

        private void ClearFields()
        {
            textBoxCount.Text = "";
            textBoxDescription.Text = "";
            textBoxName.Text = "";
            textBoxPrice.Text = "";
        }

        private void AddProduct()
        {
            if (imageMiniView.ImageUrl == "")
            {
                imageMiniView.ImageUrl = "~/Image/none.png";
            }
            Item item = new Item()
            {
                Name = textBoxName.Text,
                Price = Double.Parse(textBoxPrice.Text.Trim().Replace(".", ",")),
                Description = textBoxDescription.Text,
                Count = Int32.Parse(textBoxCount.Text),
                ImagePath = imageMiniView.ImageUrl
            };
            using (CommonClient client = new CommonClient())
            {
                client.Open();
                client.AddItem(item);
                client.Close();
            }
            ClearFields();
            Response.Redirect(Request.RawUrl);
        }

        private void UploadPicture()
        {

            String savePath = HttpContext.Current.Server.MapPath("~/Image/");
            String fileName = "none.png";
            if (imageLoader.HasFile)
            {
                fileName = imageLoader.FileName;
                savePath += fileName;
                imageLoader.SaveAs(savePath);
            }
            imageMiniView.ImageUrl = String.Format("~/Image/{0}", fileName);
        }
    }
}