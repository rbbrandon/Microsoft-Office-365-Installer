using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOffice365Install
{
    [Serializable]
    public class Settings
    {
        public bool Silent = false;
        public bool Force32BitOn64BitOS = false;
        public string SourcePath = null;
        public string UpdatePath = null;
        public string ChannelId = Channel.Monthly;
        public string SchoolLogo = null;
        public string LicenceLink = null;
        public List<string> InstallProducts = new List<string>()
        {
            "Office"
        };
        public List<string> ExcludeApps = new List<string>()
        {
            "Lync"
        };
    }
}
