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
    public partial class ManageItemsWizard : System.Web.UI.UserControl
    {
        Item[] items;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (CommonClient client = new CommonClient())
            {
                client.Open();
                items = client.GetAllItems();
                client.Close();
            }
            if (items != null)
                TableRowsCreate(items);
        }

        private void TableRowsCreate(Item[] items)
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


                Button btnDel = new Button();
                btnDel.Click += new EventHandler(btnDel_Click);
                btnDel.CssClass = "btn btn-danger";
                btnDel.Text = "Удалить";

                HiddenField hideID = new HiddenField();
                hideID.Value = items[i].ID.ToString();

                TableCell tc = new TableCell();
                tc.Controls.Add(btnDel);
                tc.Controls.Add(hideID);
                tr.Cells.Add(tc);


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

        void btnDel_Click(object sender, EventArgs e)
        {
            TableCell tc = (sender as Button).Parent as TableCell;

            foreach (var item in tc.Controls)
            {
                if (item is HiddenField)
                {
                    int id = Int32.Parse((item as HiddenField).Value);

                    using (CommonClient client = new CommonClient())
                    {
                        client.Open();

                        Item itemProduct = client.GetItem(id);
                        client.Remove(itemProduct);
                        /*IEnumerable<User> users = client.GetUsers();
                        foreach (var user in users)
                        {
                            client.RemoveFromCard(user.ID, id);
                        }*/
                        client.Close();
                    }

                    break;
                }
            }

            Response.Redirect(Request.RawUrl);
        }
    }
}