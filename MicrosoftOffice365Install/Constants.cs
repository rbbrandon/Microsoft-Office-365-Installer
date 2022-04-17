using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace MicrosoftOffice365Install
{
    public static class Constants
    {
        public static string DnsTxtRecord = "officecdn" + "." + System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        public static string OfficeConfigurationRegKey = /*HKLM:*/@"SOFTWARE\Microsoft\Office\ClickToRun\Configuration";
        //public static string NetworkShare = @"http://office365.kurnaicollege.vic.edu.au/";
        // Default CDN for "Insider" channel: http://officecdn.microsoft.com/pr/5440fd1f-7ecb-4221-8110-145efaa6372f
        public static string DomainRegEx = @"^(?:https?:\/\/)?(?:[^@\n]+@)?(?:www\.)?([^:\/\n?]+)"; // https://regex101.com/r/wN6cZ7/365
        public static string TempPath = Path.GetTempPath() + @"Office365\";
        public static string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;
        public static string ConfigFileName = System.Diagnostics.Process.GetCurrentProcess()?.MainModule.FileName + ".xml";
        public static string[] SilentSwitches = { "/s", "/silent", "/q", "/quiet" };
        public static string[] FullSwitches = { "/f", "/full" };
        public static string[] VolumeSwitches = { "/v", "/volume" };
        public static string[] ChannelSwitches = { "/c", "/channel" };
        public static string[] ValidChannels = { "Monthly", "MonthlyTargeted", "SemiAnnual", "SemiAnnualTargeted", "Volume" };
    }
}
