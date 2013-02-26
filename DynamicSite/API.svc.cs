using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Drawing;

namespace DynamicSite
{
    [ServiceContract(Namespace = "DynamicSite", Name = "API")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class API
    {
        [OperationContract]        
        [WebGet]
        public string Msg(string name)
        {
            return String.Format("Hello, {0}! I'm Service!", name);
        }

        [OperationContract]
        [WebGet]
        public string[][] Fill()
        {
            string[][] data = new string[2][];
            data[0] = new string[5] {"1", "Игрушка мягкая", "250", "8", "2000"};            
            data[1] = new string[5] {"2", "Холодильник", "4500", "1", "4500"};
            return data;
        }


        [OperationContract]
        [WebGet]
        public Bitmap Bmp()
        {
            int w = 3;
            int h = 3;

            var bmp = new Bitmap(w,h);

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    bmp.SetPixel(i, j, Color.Black);
                }
            }

            return bmp;
        }
    }
}
