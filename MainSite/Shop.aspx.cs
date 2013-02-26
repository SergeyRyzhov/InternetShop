using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MainSite.UserControls;
using MainSite.Common;
using CommonLibrary.Entities;

namespace MainSite
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                using (CommonClient client = new CommonClient())
                {
                    client.Open();

                    var items = client.GetAllItems();

                    foreach (var item in items)
                    {
                        Panel1.Controls.Add(GetItemView(item));
                    }

                    client.Close();
                }
            }

        }
        protected ItemViewMini GetItemView(Item item)
        {
            ItemViewMini view = Page.LoadControl("~\\UserControls\\ItemViewMini.ascx") as ItemViewMini;
            view.ItemName = item.Name;
            view.Description = item.Description;
            view.Price = item.Price.ToString();
            view.Count = item.Count.ToString();
            view.productID = item.ID;
            view.ImagePath = item.ImagePath;
            return view;
        }
    }
} 