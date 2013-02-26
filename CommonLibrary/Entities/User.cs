using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CommonLibrary.Entities
{
    [DataContract]
    public class User : IEquatable<User>
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [BLToolkit.Mapping.MapField("Login")]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        #region IEquatable<User> Members

        public bool Equals(User other)
        {
            return ID == other.ID;
        }

        #endregion
    }
}