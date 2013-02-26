using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using CommonLibrary.Entities;

namespace InternetShopService.EntitiesAccessors
{
    public abstract class BuyAccessor : DataAccessor
    {
        //[SqlQuery("select * from buyhistory")]
        //public abstract List<BuyHistoryItem> GetBuyHistory();

        [SprocName("GetButHistory")]
        public abstract List<BuyHistoryItem> GetBuyHistory();
    }
}