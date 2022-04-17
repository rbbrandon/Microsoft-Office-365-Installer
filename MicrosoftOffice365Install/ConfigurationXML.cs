using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace MicrosoftOffice365Install
{
    public class ConfigurationXML
    {
        public bool UpdatesEnabled = true;
        public bool ForceAppShutdown = true;
        public bool PinIconsToTaskbar = true;
        public bool RemoveMSI = true;
        public bool AllowCdnFallback = true;
        public bool ForceUpgrade = true;
        public bool MigrateArch = true;
        public bool DisplayUI = true;

        public string SourcePath = String.Empty;
        public string UpdatePath = String.Empty;
        public string ClientEdition = String.Empty;
        public string ChannelId = Channel.Monthly;

        public List<ConfigurationXMLProduct> AddProducts = new List<ConfigurationXMLProduct>();

        public ConfigurationXML()
        {
            ClientEdition = Environment.Is64BitOperatingSystem ? OfficeClientEdition.X64 : OfficeClientEdition.X32;
        }

        public ConfigurationXMLProduct AddProduct(string productID)
        {
            ConfigurationXMLProduct product = new ConfigurationXMLProduct(productID);
            AddProducts.Add(product);

            return product;
        }

        public bool Save(string saveFile)
        {
            bool saveSucceeded = true;

            XmlDocument xmlDocument = new XmlDocument();
            XmlElement config = (XmlElement)xmlDocument.AppendChild(xmlDocument.CreateElement("Configuration"));

            if (AddProducts.Count > 0)
            {
                XmlElement add = (XmlElement)config.AppendChild(xmlDocument.CreateElement("Add"));

                if (!String.IsNullOrEmpty(SourcePath))
                    add.SetAttribute("SourcePath", SourcePath);

                add.SetAttribute("OfficeClientEdition", ClientEdition);
                add.SetAttribute("Channel", ChannelId);

                if (AllowCdnFallback)
                    add.SetAttribute("AllowCdnFallback", "TRUE");
                if (ForceUpgrade)
                    add.SetAttribute("ForceUpgrade", "TRUE");
                if (MigrateArch)
                    add.SetAttribute("MigrateArch", "TRUE");

                foreach (ConfigurationXMLProduct product in AddProducts)
                {
                    XmlElement prod = (XmlElement)add.AppendChild(xmlDocument.CreateElement("Product"));
                    prod.SetAttribute("ID", product.ID);

                    XmlElement language = (XmlElement)prod.AppendChild(xmlDocument.CreateElement("Language"));
                    language.SetAttribute("ID", product.Language);

                    foreach (string excludedApp in product.ExcludedApps)
                    {
                        XmlElement excludeApp = (XmlElement)prod.AppendChild(xmlDocument.CreateElement("ExcludeApp"));
                        excludeApp.SetAttribute("ID", excludedApp);
                    }
                }
            }

            if (UpdatesEnabled)
            {
                XmlElement updates = (XmlElement)config.AppendChild(xmlDocument.CreateElement("Updates"));
                updates.SetAttribute("Enabled", "TRUE");

                if (!String.IsNullOrEmpty(UpdatePath))
                    updates.SetAttribute("UpdatePath", UpdatePath);

                updates.SetAttribute("Channel", ChannelId);
            }

            XmlElement display = (XmlElement)config.AppendChild(xmlDocument.CreateElement("Display"));
            display.SetAttribute("Level", DisplayUI ? DisplayLevel.Full : DisplayLevel.None);
            display.SetAttribute("AcceptEULA", "TRUE");

            if (ForceAppShutdown)
            {
                XmlElement forceAppShutdown = (XmlElement)config.AppendChild(xmlDocument.CreateElement("Property"));
                forceAppShutdown.SetAttribute("Name", "FORCEAPPSHUTDOWN");
                forceAppShutdown.SetAttribute("Value", "TRUE");
            }

            if (PinIconsToTaskbar)
            {
                XmlElement pinIconsToTaskbar = (XmlElement)config.AppendChild(xmlDocument.CreateElement("Property"));
                pinIconsToTaskbar.SetAttribute("Name", "PinIconsToTaskbar");
                pinIconsToTaskbar.SetAttribute("Value", "TRUE");
            }

            if (RemoveMSI)
                config.AppendChild(xmlDocument.CreateElement("RemoveMSI"));
            
            if (!Directory.Exists(new FileInfo(saveFile).Directory.FullName))
                Directory.CreateDirectory(new FileInfo(saveFile).Directory.FullName);

            File.WriteAllText(saveFile, XElement.Parse(xmlDocument.OuterXml).ToString());

            return saveSucceeded;
        }
    }
}
