using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;

namespace Scribblers
{
    public class Msg
    {
        public Msg() { }
        public string msg { get; set; }
        public string name { get; set; }
    }
    public abstract class MessageManager : DataAccessor
    {
        [SqlQuery(@"SELECT Count(*) 
                    FROM Messages")]
        public abstract int Count();

        [SqlQuery(@"SELECT TOP 25 msg, name
                    FROM Messages 
                    ORDER BY id DESC")]
        public abstract List<Msg> Last25();


        [SqlQuery(@"INSERT INTO Messages (msg, name) 
                    VALUES (@msg, @name)")]
        public abstract void Say(string msg, string name = "anonym");

        [SqlQuery(@"DELETE FROM Messages 
                    WHERE ID < 
                        (SELECT max(id) 
                        FROM Messages) - 50")]
        public abstract void Clear();


        [SqlQuery(@"DELETE FROM Messages")]
        public abstract void HardClear();
    }
}