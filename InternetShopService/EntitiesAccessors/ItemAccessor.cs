using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using CommonLibrary;
using CommonLibrary.Entities;

namespace InternetShopService.EntitiesAccessors
{
    public abstract class ItemAccessor : DataAccessor
    {
        [SprocName("GetAllItems")]
        public abstract List<Item> GetAll();

        [SprocName("GetShoppingCard")]
        public abstract List<Item> GetShoppingCard(int userID);


        [SprocName("GetItemById")]
        public abstract Item GetItem(int itemID);

        public Item AddItem(Item item)
        {
            using (var db = GetDbManager())
            {
                return db.SetSpCommand("AddItem",
                    db.Parameter("@name", item.Name),
                    db.Parameter("@price", item.Price),
                    db.Parameter("@description", item.Description),
                    db.Parameter("@count", item.Count),
                    db.Parameter("@imagepath", item.ImagePath))
                .ExecuteObject<Item>();
            }
        }

        [SprocName("RemoveItem")]
        public abstract void RemoveItem(int itemID);

        public bool RemoveItemFromCard(int itemID, int userID)
        {
            using (var db = GetDbManager())
            {
                db.SetSpCommand("RemoveFromCard",
                    db.Parameter("@itemID", itemID),
                    db.Parameter("@userID", userID))
                .ExecuteNonQuery();
                return true;
            }
        }

        public List<Item> AddItemToCard(int itemID, int userID, int count)
        {
            using (var db = GetDbManager())
            {
                return db.SetSpCommand("AddItemToCard",
                    db.Parameter("@itemID", itemID),
                    db.Parameter("@userID", userID),
                    db.Parameter("@count", count))
                .ExecuteList<Item>();
            }
        }

        [SprocName("BuyItem")]
        public abstract List<Item> BuyItem(int itemID, int userID);

        [SprocName("GetOrderList")]
        public abstract List<Item> GetOrderList(int userID);
    }
}