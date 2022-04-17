using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Microsoft.Win32;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MicrosoftOffice365Install
{
    public static class Util
    {
        public static void WriteResourceToFile(string resourceName, string fileName)
        {
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    CopyStream(resource, file);
                }
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            // Insert null checking here for production
            byte[] buffer = new byte[8192];

            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }

        // http://stackoverflow.com/a/924682
        public static bool URLContactable(string url)
        {
            // using MyClient from linked post
            using (var client = new MyClient())
            {
                client.HeadOnly = true;
                // fine, no content downloaded
                try
                {
                    client.DownloadString(url);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public static void ExtractZipResourceToFolder(string resourceName, string extractPath)
        {
            Stream _pluginZipResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

            using (ZipArchive archive = new ZipArchive(_pluginZipResourceStream, ZipArchiveMode.Read))
            {
                if (!Directory.Exists(extractPath))
                    Directory.CreateDirectory(extractPath);

                foreach (ZipArchiveEntry entry in archive.Entries)
                    entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
            }
        }

        // Source: https://stackoverflow.com/a/7203926
        public static bool RunInstallMSI(string sMSIPath)
        {
            try
            {
                Console.WriteLine("Starting to install application");
                Process process = new Process();
                process.StartInfo.FileName = "msiexec.exe";
                process.StartInfo.Arguments = string.Format(" /qb /i \"{0}\" ALLUSERS=1", sMSIPath);
                process.Start();
                process.WaitForExit();
                Console.WriteLine("Application installed successfully!");
                return true; //Return True if process ended successfully
            }
            catch
            {
                Console.WriteLine("There was a problem installing the application!");
                return false;  //Return False if process ended unsuccessfully
            }
        }

        // Source: https://stackoverflow.com/a/7203926
        public static bool RunUninstallMSI(string guid)
        {
            try
            {
                Console.WriteLine("Starting to uninstall application");
                ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", string.Format("/c start /MIN /wait msiexec.exe /x {0} /passive", guid));
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process process = Process.Start(startInfo);
                process.WaitForExit();
                Console.WriteLine("Application uninstalled successfully!");
                return true; //Return True if process ended successfully
            }
            catch
            {
                Console.WriteLine("There was a problem uninstalling the application!");
                return false; //Return False if process ended unsuccessfully
            }
        }

        public static bool IsApplictionInstalled(string p_name)
        {
            return (GetProductRegistryKey(p_name) != null);
        }

        public static string GetApplicationMSICode(string p_name)
        {
            string msiCode = "";

            RegistryKey key = GetProductRegistryKey(p_name);
            
            if (key != null)
            {
                System.Windows.Forms.MessageBox.Show(key.ToString());
                string uninstallString = key.GetValue("UninstallString") as string;

                if (StringInStr(uninstallString, "MsiExec") && StringInStr(uninstallString, "{"))
                {
                    // Product is an MSI install.
                    msiCode = Regex.Match(uninstallString, @"(\{.*\})").Groups[1].Value;
                }
            }

            return msiCode;
        }

        // Based on http://mdb-blog.blogspot.com/2010/09/c-check-if-programapplication-is.html
        public static RegistryKey GetProductRegistryKey(string p_name)
        {
            RegistryKey key;
            string displayName;

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return subkey;
                }
            }

            // search in: LocalMachine_64
            if (Environment.Is64BitOperatingSystem)
            {
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return subkey;
                    }
                }
            }

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return subkey;
                }
            }

            // Product not found
            return null;
        }

        public static bool StringInStr(string text, string word)
        {
            return (text.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
