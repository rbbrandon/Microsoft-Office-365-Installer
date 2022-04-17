using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOffice365Install
{
    public class ConfigurationXMLProduct
    {
        public string ID;
        public string Language = "en-us";
        public List<string> ExcludedApps = new List<string>();

        public ConfigurationXMLProduct(string productID, string language)
        {
            ID = productID;
            Language = language;
        }

        public ConfigurationXMLProduct(string productID)
        {
            ID = productID;
        }

        public void ExcludeApp(string appID)
        {
            if (!ExcludedApps.Contains(appID))
                ExcludedApps.Add(appID);
        }
    }
}
