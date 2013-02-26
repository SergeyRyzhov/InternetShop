using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using CommonLibrary.Entities;
using MainSite.Common;

namespace MainSite.UserControls
{
    public partial class ShoppingCard : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Load += new EventHandler(ShoppingCard_Load);
        }

        private Item[] items;
        void ShoppingCard_Load(object sender, EventArgs e)
        {
            /*CommonClient c = new CommonClient();
            bool flag = (c is 
                InternetShopService.ICommon);*/
            {
                IUnityContainer container = new UnityContainer();
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                section.Configure(container);

                ICommon client = container.Resolve<ICommon>();
                {
                    string login = Page.User.Identity.Name;
                    User user = client.GetUser(login);
                    items = (client as ICommon).GetShoppingCard(user).ToArray<Item>();
                }
            }

            /*using ( CommonClient client = new CommonClient())
            {
                client.Open();

                string login = Page.User.Identity.Name;
                User user = client.GetUser(login);
                items = client.GetShoppingCard(user);
                client.Close();
            }*/
            if (items != null)
            {
                int i = 1;
                GridViewShopCard.DataSource = items.Select(x =>
                    new
                    {
                        Count = x.Count,
                        ID = x.ID,
                        Name = x.Name,
                        Price = x.Price,
                        Number = i++,
                        Cost = x.Price * x.Count
                    });

                GridViewShopCard.DataBind();
            }
        }

        private void DelItem(Item itemProduct)
        {
            using (CommonClient client = new CommonClient())
            {
                client.Open();
                string login = Page.User.Identity.Name;
                User user = client.GetUser(login);

                client.RemoveFromCard(user, itemProduct);

                client.Close();
            }
            Response.Redirect(Request.RawUrl);
        }
        double totalCost = 0;

        protected void GridViewShopCard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (string.Equals(e.CommandName, "Delete", StringComparison.OrdinalIgnoreCase))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DelItem(items[index]);
            }
        }

        protected void GridViewShopCard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCost = (Label)e.Row.FindControl("lblCost");
                double cost = double.Parse(lblCost.Text);
                totalCost += cost;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalCost = (Label)e.Row.FindControl("lblTotalCost");
                lblTotalCost.Text = totalCost.ToString();
            }
        }
    }
}