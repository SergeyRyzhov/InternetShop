using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLibrary.Entities;
using CommonLibrary;

namespace MainSite
{
    public class TestProvider: MainSite.Common.ICommon
    {
        #region ICommon Members

        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Item AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetOrder(User user)
        {
            throw new NotImplementedException();
        }

        public bool MakeOrder(User user)
        {
            throw new NotImplementedException();
        }

        public List<Item> AddToCardItem(User user, Item item, int count = 1)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromCard(User user, Item item)
        {
            throw new NotImplementedException();
        }

        public List<BuyHistoryItem> GetBuyHistory()
        {
            throw new NotImplementedException();
        }


        public User GetUser(string login)
        {
            return new User()
            {
                ID = 1,
                Name = login
            };
            throw new NotImplementedException();
        }

        #endregion

        #region ICommon Members


        User[] Common.ICommon.GetUsers()
        {
            throw new NotImplementedException();
        }

        Item[] Common.ICommon.GetAllItems()
        {
            throw new NotImplementedException();
        }

        Item[] Common.ICommon.GetShoppingCard(User user)
        {
            Item item = new Item()
            {
                Name = "Тест",
                Count = 1,
                Price = 10,
                ID = 1
            };
            return new Item[1] { item };
        }

        Item[] Common.ICommon.GetOrder(User user)
        {
            throw new NotImplementedException();
        }

        Item[] Common.ICommon.AddToCardItem(User user, Item item, int count)
        {
            throw new NotImplementedException();
        }

        BuyHistoryItem[] Common.ICommon.GetBuyHistory()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}