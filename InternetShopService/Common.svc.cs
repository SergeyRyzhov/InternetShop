using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BLToolkit.Reflection;
using CommonLibrary.Entities;
using InternetShopService.EntitiesAccessors;
using CommonLibrary;
using InternetShopService.Core;

namespace InternetShopService
{
    public class Common : ICommon, IDisposable
    {
        public Common()
        {
            Logger.Log.Info(string.Format("{0} is started", this.GetType()));
        }

        #region IDisposable Members

        public void Dispose()
        {
            Logger.Log.Info(string.Format("{0} is stopped", this.GetType()));
        }

        #endregion

        #region User Manager Members

        public User AddUser(User user)
        {
            Logger.Log.Info("AddUser");
            var typeAccessor = TypeAccessor<UserAccessor>.CreateInstance();
            return typeAccessor.AddUser(user);
        }

        public bool RemoveUser(User user)
        {
            Logger.Log.Info("RemoveUser");
            var typeAccessor = TypeAccessor<UserAccessor>.CreateInstance();
            typeAccessor.RemoveUser(user.Name.ToLower());
            return true;
        }

        public User GetUser(string login)
        {
            Logger.Log.Info("GetUser");
            var typeAccessor = TypeAccessor<UserAccessor>.CreateInstance();
            return typeAccessor.GetUser(typeAccessor.GetUserID(login.ToLower()));
        }

        public IEnumerable<User> GetUsers()
        {
            Logger.Log.Info("GetUser");
            var typeAccessor = TypeAccessor<UserAccessor>.CreateInstance();
            return typeAccessor.GetAll();
        }

        #endregion

        #region Content Provider Members

        public IEnumerable<Item> GetAllItems()
        {
            Logger.Log.Info("GetAllItems");
            var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();

            var list = typeAccessor.GetAll();
            foreach (var item in list)
            {
                if (item.Count == 0)
                    item.Name = String.Format("{0} - ожидает поступления на склад", item.Name);
            }
            return list;
        }

        public Item AddItem(Item item)
        {
            Logger.Log.Info("AddItem");
            var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();
            return typeAccessor.AddItem(item);
        }

        public bool Remove(Item item)
        {
            Logger.Log.Info("RemoveItem");
            var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();
            typeAccessor.RemoveItem(item.ID);
            return true;
        }



        public Item GetItem(int id)
        {
            Logger.Log.Info("GetItem");
            var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();
            Item item = typeAccessor.GetItem(id);
            return item;
        }

        #endregion

        #region Purchase Transactions Members

        public IEnumerable<Item> GetShoppingCard(User user)
        {
            Logger.Log.Info("GetShoppingCard");
            var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();
            var list = typeAccessor.GetShoppingCard(user.ID);
            return list;
        }

        public IEnumerable<Item> GetOrder(User user)
        {
            Logger.Log.Info(String.Format("GetOrder user {0}", user.Name));
            var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();
            return typeAccessor.GetOrderList(user.ID);
        }

        public bool MakeOrder(User user)
        {
            Logger.Log.Info(String.Format("MakeOrder user {0}", user.Name));
            try
            {
                IEnumerable<Item> order = GetOrder(user);

                var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();

                foreach (var item in order)
                {
                    typeAccessor.BuyItem(item.ID, user.ID);
                }
                return true;
            }
            catch (Exception e)
            {
                Logger.Log.Error(e);
                return false; 
            }
        }

        public List<Item> AddToCardItem(User user, Item item, int count = 1)
        {
            Logger.Log.Info("AddItemToCard");
            try
            {
                var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();
                return typeAccessor.AddItemToCard(item.ID, user.ID, count);
            }
            catch (Exception e)
            {
                Logger.Log.Error(e);
            }

            return null;  
        }

        public bool RemoveFromCard(User user, Item item)
        {
            Logger.Log.Info("RemoveFromCard");
            var typeAccessor = TypeAccessor<ItemAccessor>.CreateInstance();
            return typeAccessor.RemoveItemFromCard(item.ID, user.ID);
        }

        public List<BuyHistoryItem> GetBuyHistory()
        {
            var buyAccessor = TypeAccessor<BuyAccessor>.CreateInstance();
            return buyAccessor.GetBuyHistory();
        }

        #endregion
    }
}
