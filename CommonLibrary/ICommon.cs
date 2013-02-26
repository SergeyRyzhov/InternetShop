using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommonLibrary.Entities;

namespace CommonLibrary
{
    [ServiceContract]
    public interface ICommon
    {
        #region User Manager Members

        [OperationContract]
        User AddUser(User user);
        [OperationContract]
        bool RemoveUser(User user);
        [OperationContract]
        User GetUser(string login);
        [OperationContract]
        IEnumerable<User> GetUsers();

        #endregion

        #region Content Provider Members

        [OperationContract]
        IEnumerable<Item> GetAllItems();
        [OperationContract]
        Item AddItem(Item item);
        [OperationContract]
        bool Remove(Item item);

        [OperationContract]
        Item GetItem(int id);

        #endregion

        #region Purchase Transactions Members

        [OperationContract]
        IEnumerable<Item> GetShoppingCard(User user);
        [OperationContract]
        IEnumerable<Item> GetOrder(User user);
        [OperationContract]
        bool MakeOrder(User user);
        [OperationContract]
        List<Item> AddToCardItem(User user, Item item, int count = 1);
        [OperationContract]
        bool RemoveFromCard(User user, Item item);
        [OperationContract]
        List<BuyHistoryItem> GetBuyHistory();

        #endregion
    }

}