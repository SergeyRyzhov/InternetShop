using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using BLToolkit.Reflection;

namespace Scribblers
{
    [ServiceContract(Namespace = "Scribblers", Name = "SGSAPI")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SGSAPI
    {
        //private static int countmsg = 0;

        [OperationContract]
        [WebGet]
        public string[] Last25()
        {
            var typeAccessor = TypeAccessor<MessageManager>.CreateInstance();
            //typeAccessor.Say("test", "admin");
            var result = typeAccessor.Last25();
            return result.Select(x => String.Format("{0}: {1}", x.name, x.msg)).ToArray();
        }

        [OperationContract]
        [WebGet]
        public string[] Say(string msg, string name = "anonym")
        {
            var typeAccessor = TypeAccessor<MessageManager>.CreateInstance();
            typeAccessor.Say(msg, name);
            if (typeAccessor.Count() > 50)
                typeAccessor.Clear();
            var result = typeAccessor.Last25();
            return result.Select(x => String.Format("{0}: {1}", x.name, x.msg)).ToArray();
        }

        [OperationContract]
        [WebGet]
        public string[] Clear() 
        {
            var typeAccessor = TypeAccessor<MessageManager>.CreateInstance();
            typeAccessor.Clear();
            var result = typeAccessor.Last25();
            return result.Select(x => String.Format("{0}: {1}", x.name, x.msg)).ToArray();
        }

        [OperationContract]
        [WebGet]
        public string[] HardClear()
        {
            var typeAccessor = TypeAccessor<MessageManager>.CreateInstance();
            typeAccessor.HardClear();
            var result = typeAccessor.Last25();
            return result.Select(x => String.Format("{0}: {1}", x.name, x.msg)).ToArray();
        }
    }
}
