using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CommonLibrary.Entities
{
    [DataContract]
    public class Item : IEquatable<Item>
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public string ImagePath { get; set; }

        #region IEquatable<Item> Members

        public bool Equals(Item other)
        {
            return ID == other.ID;
        }

        #endregion
    }
}