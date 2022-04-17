using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Linq;
using System.Collections.ObjectModel; // PowerShell
using System.Net;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MicrosoftOffice365Install
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (ProductSelectionGUI productGUI = new ProductSelectionGUI())
            {
                if (productGUI.ShowDialog() == DialogResult.Yes)
                {
                    // Make loading progress bar.
                    using (Progress prepareProgress = new Progress()
                    {
                        Text = "Preparing Setup"
                    })
                    {
                        prepareProgress.label1.Text = "Please Wait...";
                        prepareProgress.labelledProgressBar1.Text = "Updating configuration file...";
                        prepareProgress.Show();

                        // Update progress bar
                        prepareProgress.label1.Text = "Extracting required setup files...";
                        prepareProgress.labelledProgressBar1.Text = "Extracting \"setup.exe\"...";
                        prepareProgress.labelledProgressBar1.Value = 10;
                        prepareProgress.Refresh();
                        
                        Util.WriteResourceToFile("MicrosoftOffice365Install.Resources.setup.exe", Constants.TempPath + "setup.exe");
                        //Util.WriteResourceToFile("MicrosoftOffice365Install.Resources.remove-all.xml", Constants.TempPath + "remove-all.xml");

                        /* Uninstall previous Office versions
                        // To-Do
                        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(Constants.OfficeConfigurationRegKey))
                        {
                            try
                            {
                                if (key != null)
                                {
                                    string productReleaseIds = key.GetValue("ProductReleaseIds") as String;
                                    string platform = key.GetValue("Platform") as String;

                                    if (!productReleaseIds.Contains("O365ProPlusRetail")) {
                                        // C2R installed but not 365 ProPlus. Uninstall previous versions.
                                        prepareProgress.label1.Text = "Uninstalling older versions of Office products...";
                                        prepareProgress.labelledProgressBar1.Text = "Uninstalling...";
                                        prepareProgress.labelledProgressBar1.Value = 20;
                                        prepareProgress.Refresh();

                                        // Run uninstall
                                        try
                                        {
                                            ProcessStartInfo setupInfo = new ProcessStartInfo()
                                            {
                                                UseShellExecute = true,
                                                WorkingDirectory = Constants.TempPath,
                                                FileName = Constants.TempPath + "setup.exe",
                                                Arguments = "/configure \"" + Constants.TempPath + "remove-all.xml\"",
                                                //Verb = "runas",
                                                WindowStyle = ProcessWindowStyle.Hidden
                                            };

                                            // Run the setup file, and wait for exit.
                                            using (Process setupProcess = Process.Start(setupInfo))
                                            {
                                                setupProcess.WaitForExit();
                                            }
                                        }
                                        catch { }
                                    }
                                }
                            } catch { }
                        }
                        */
                        // Run setup
                        try
                        {
                            ProcessStartInfo setupInfo = new ProcessStartInfo()
                            {
                                UseShellExecute = true,
                                WorkingDirectory = Constants.TempPath,
                                FileName = Constants.TempPath + "setup.exe",
                                Arguments = "/configure \"" + Constants.TempPath + "configuration.xml\"",
                                //Verb = "runas",
                                WindowStyle = ProcessWindowStyle.Hidden
                            };

                            // Run the setup file, and wait for exit.
                            using (Process setupProcess = Process.Start(setupInfo))
                            {
                                prepareProgress.label1.Text = "Installing Office365...";
                                prepareProgress.labelledProgressBar1.Text = "Please wait (this might take a while)...";
                                prepareProgress.labelledProgressBar1.Value = 50;
                                prepareProgress.Refresh();

                                setupProcess.WaitForExit();
                            }
                        }
                        catch { }
                    }
                }
            }

            // Cleanup temp files
            if (Directory.Exists(Constants.TempPath))
                Directory.Delete(Constants.TempPath, true);
        }
    }
}
