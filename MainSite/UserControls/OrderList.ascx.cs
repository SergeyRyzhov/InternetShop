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
    public partial class OrderList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item[] items;
            using (CommonClient client = new CommonClient())
            {
                client.Open();

                string login = Page.User.Identity.Name;
                User user = client.GetUser(login);
                items = client.GetOrder(user);
                client.Close();
            }
            if (items != null)
                TableRowsItemsCreate(items);

        }

        private void TableRowsItemsCreate(Item[] items)
        {
            double total = 0.0;
            double current = 0.0;
            for (int i = 0; i < items.Count(); i++)
            {
                TableRow tr = new TableRow();
                tr.Cells.Add(new TableCell() { Text = (i + 1).ToString() });
                tr.Cells.Add(new TableCell() { Text = items[i].Name.ToString() });
                tr.Cells.Add(new TableCell() { Text = items[i].Price.ToString() });
                tr.Cells.Add(new TableCell() { Text = items[i].Count.ToString() });


                current = items[i].Count * items[i].Price;
                total += current;

                tr.Cells.Add(new TableCell() { Text = current.ToString() });

                Table1.Rows.Add(tr);
            }

            if (items.Count() > 0)
            {
                TableFooterRow trTotal = new TableFooterRow();
                trTotal.Cells.Add(new TableCell() { ColumnSpan = 3 });
                trTotal.Cells.Add(new TableCell() { Text = "Итого", ColumnSpan = 1 });
                trTotal.Cells.Add(new TableCell() { Text = total.ToString() });
                trTotal.Cells.Add(new TableCell() { });
                Table1.Rows.Add(trTotal);
            }
            else
            {
                TableFooterRow trTotal = new TableFooterRow();
                trTotal.Cells.Add(new TableCell() { ColumnSpan = 3 });
                trTotal.Cells.Add(new TableCell() { Text = "Покупок нет", ColumnSpan = 1 });
                trTotal.Cells.Add(new TableCell() { ColumnSpan = 2 });
                Table1.Rows.Add(trTotal);
            }
        }
    }
}