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
    public partial class BuyHistoryWizard : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BuyHistoryItem[] buyhistory = null;
            using (CommonClient client = new CommonClient())
            {
                client.Open();
                buyhistory = client.GetBuyHistory();
                client.Close();
            }
            TableRowsCreate(buyhistory);
        }

        private void TableRowsCreate(BuyHistoryItem[] buyhistory)
        {
            double total = 0.0;
            double current = 0.0;

            int count = buyhistory.Count();
            int i = 1;
            foreach (var item in buyhistory)
            {
                TableRow tr = new TableRow();
                tr.Cells.Add(new TableCell() { Text = (i++).ToString() });
                tr.Cells.Add(new TableCell() { Text = item.Login.ToString() });
                tr.Cells.Add(new TableCell() { Text = item.Name.ToString() });
                tr.Cells.Add(new TableCell() { Text = item.Price.ToString() });
                tr.Cells.Add(new TableCell() { Text = item.Count.ToString() });


                current = item.Count * item.Price;
                total += current;

                tr.Cells.Add(new TableCell() { Text = current.ToString() });

                Table1.Rows.Add(tr);

            }

            if (count > 0)
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