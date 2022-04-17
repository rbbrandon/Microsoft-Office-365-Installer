using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Linq;

// Thanks http://xmltocsharp.azurewebsites.net/
namespace MicrosoftOffice365Install
{
	[XmlRoot(ElementName = "Language")]
	public class Language
	{
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
	}

	[XmlRoot(ElementName = "ExcludeApp")]
	public class ExcludeApp
	{
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
	}

	[XmlRoot(ElementName = "Product")]
	public class Product
	{
		[XmlElement(ElementName = "Language")]
		public List<Language> Language { get; set; }
		[XmlElement(ElementName = "ExcludeApp")]
		public List<ExcludeApp> ExcludeApp { get; set; }
		[XmlAttribute(AttributeName = "ID")]
		public string ID { get; set; }
		[XmlAttribute(AttributeName = "PIDKEY")]
		public string PIDKEY { get; set; }
	}

	[XmlRoot(ElementName = "Add")]
	public class Add
	{
		[XmlElement(ElementName = "Product")]
		public List<Product> Product { get; set; }
		[XmlAttribute(AttributeName = "SourcePath")]
		public string SourcePath { get; set; }
		[XmlAttribute(AttributeName = "OfficeClientEdition")]
		public string OfficeClientEdition { get; set; }
		[XmlAttribute(AttributeName = "Channel")]
		public string Channel { get; set; }
		[XmlAttribute(AttributeName = "AllowCdnFallback")]
		public string AllowCdnFallback { get; set; }
		[XmlAttribute(AttributeName = "MigrateArch")]
		public string MigrateArch { get; set; }
		[XmlAttribute(AttributeName = "ForceUpgrade")]
		public string ForceUpgrade { get; set; }
	}

	[XmlRoot(ElementName = "Property")]
	public class Property : IEquatable<Property>
	{
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "Value")]
		public string Value { get; set; }

		public override bool Equals(object obj)
		{
			return this.Equals(obj as Property);
		}

		public bool Equals(Property other)
		{
			if (other == null)
				return false;

			return this.Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) &&
				this.Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode() {
			return (this.Name + " : " + this.Value).GetHashCode();
		}
	}

	[XmlRoot(ElementName = "Updates")]
	public class Updates
	{
		[XmlAttribute(AttributeName = "Enabled")]
		public string Enabled { get; set; }
		[XmlAttribute(AttributeName = "UpdatePath")]
		public string UpdatePath { get; set; }
		[XmlAttribute(AttributeName = "Channel")]
		public string Channel { get; set; }
	}

	[XmlRoot(ElementName = "Setup")]
	public class Setup
	{
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "Value")]
		public string Value { get; set; }
	}

	// <User Key="software\microsoft\office\16.0\excel\options" Name="defaultformat" Value="51" Type="REG_DWORD" App="excel16" Id="L_SaveExcelfilesas" />
	[XmlRoot(ElementName = "User")]
	public class User
	{
		[XmlAttribute(AttributeName = "Key")]
		public string Key { get; set; }
		[XmlAttribute(AttributeName = "Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "Value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "Type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "App")]
		public string App { get; set; }
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "AppSettings")]
	public class AppSettings
	{
		[XmlElement(ElementName = "Setup")]
		public Setup Setup { get; set; }
		[XmlElement(ElementName = "User")]
		public List<User> User { get; set; }
	}

	[XmlRoot(ElementName = "Display")]
	public class Display
	{
		[XmlAttribute(AttributeName = "Level")]
		public string Level { get; set; }
		[XmlAttribute(AttributeName = "AcceptEULA")]
		public string AcceptEULA { get; set; }
	}

	[XmlRoot(ElementName = "Logging")]
	public class Logging
	{
		[XmlAttribute(AttributeName = "Level")]
		public string Level { get; set; }
		[XmlAttribute(AttributeName = "Path")]
		public string Path { get; set; }
	}

	[XmlRoot(ElementName = "Configuration")]
	public class Configuration
	{
		[XmlElement(ElementName = "Add")]
		public Add Add { get; set; }
		[XmlElement(ElementName = "Property")]
		public List<Property> Property { get; set; }
		[XmlElement(ElementName = "Updates")]
		public Updates Updates { get; set; }
		[XmlElement(ElementName = "AppSettings")]
		public AppSettings AppSettings { get; set; }
		[XmlElement(ElementName = "Display")]
		public Display Display { get; set; }
		[XmlElement(ElementName = "Logging")]
		public Logging Logging { get; set; }
		[XmlElement(ElementName = "RemoveMSI")]
		public string RemoveMSI { get; set; }

		public Configuration()
		{
			// Set Defaults:
			Add = new Add()
			{
				Channel = Channel.MonthlyEnterprise,
				AllowCdnFallback = "TRUE",
				MigrateArch = "TRUE",
				ForceUpgrade = "TRUE"
			};

			Add.Product = new List<Product>()
			{
				new Product()
				{
					ID = ProductID.Office365ProPlus,
					Language = new List<Language>() { new Language() {ID = "en-us"} },
					ExcludeApp = new List<ExcludeApp>()
					{
						new ExcludeApp() { ID = AppID.SkypeForBusiness},
						new ExcludeApp() { ID = AppID.OneDriveForBusiness},
						new ExcludeApp() { ID = AppID.BingChromeExtension}
					}
				}
			};

			AppSettings = new AppSettings() {
				User = new List<User>() {
					new User() {
						Key   = "software\\microsoft\\office\\16.0\\excel\\options",
						Name  = "defaultformat",
						Value = "51",
						Type  = "REG_DWORD",
						App   = "excel16",
						Id    = "L_SaveExcelfilesas"
					},
					new User() {
						Key   = "software\\microsoft\\office\\16.0\\powerpoint\\options",
						Name  = "defaultformat",
						Value = "27",
						Type  = "REG_DWORD",
						App   = "ppt16",
						Id    = "L_SavePowerPointfilesas"
					},
					new User() {
						Key   = "software\\microsoft\\office\\16.0\\word\\options",
						Name  = "defaultformat",
						Value = "",
						Type  = "REG_SZ",
						App   = "word16",
						Id    = "L_SaveWordfilesas"
					}
				}
			};

			Property = new List<Property>()
			{
				new Property(){ Name = "SharedComputerLicensing", Value = "0"},
				new Property(){ Name = "SCLCacheOverride", Value = "0"},
				new Property(){ Name = "AUTOACTIVATE", Value = "0"},
				new Property(){ Name = "FORCEAPPSHUTDOWN", Value = "TRUE"},
				new Property(){ Name = "DeviceBasedLicensing", Value = "0"}
			};

			Updates = new Updates() { Enabled = "TRUE", Channel = Add.Channel };
			Display = new Display() { Level = "Full", AcceptEULA = "TRUE" };

			RemoveMSI = "";
		}

		public override string ToString()
		{
			var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
			var serializer = new XmlSerializer(this.GetType());
			var settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.OmitXmlDeclaration = true;

			using (var stream = new StringWriter())
			{
				using (var writer = XmlWriter.Create(stream, settings))
				{
					serializer.Serialize(writer, this, emptyNamespaces);
					return stream.ToString();
				}
			}
		}

		public bool Save(string fileName)
		{
			if (!Directory.Exists(Path.GetDirectoryName(fileName)))
				Directory.CreateDirectory(Path.GetDirectoryName(fileName));

			File.WriteAllText(fileName, this.ToString());

			if (File.Exists(fileName))
				return true;
			else
				return false;
		}
	}
}
