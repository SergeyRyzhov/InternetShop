using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonLibrary.Entities
{
    /*public class BuyHistoryItem
    {
        public int UserID { get; set; }
        public int ItemID { get; set; }
        public int Count { get; set; }
    }*/

    public class BuyHistoryItem
    {
        public String Login { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}