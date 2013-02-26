using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using CommonLibrary.Entities;

namespace InternetShopService.EntitiesAccessors
{
    public abstract class UserAccessor : DataAccessor
    {
        [SprocName("GetAllUsers")]
        public abstract List<User> GetAll();

        [SprocName("GetUserID")]
        public abstract int GetUserID(string name);

        public User AddUser(User user)
        {
            using (var db = GetDbManager())
            {
                return db.SetSpCommand("AddUser",
                    db.Parameter("@login", user.Name),
                    db.Parameter("@email", user.Email))
                .ExecuteObject<User>();
            }
        }

        public void RemoveUser(string login)
        {
            using (var db = GetDbManager())
            {
                db.SetSpCommand("RemoveUser",
                    db.Parameter("@login", login.ToLower()))
                .ExecuteNonQuery();
            }
        }

        [SprocName("GetUserById")]
        public abstract User GetUser(int userID);
    }
}