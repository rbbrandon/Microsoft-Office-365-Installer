using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace MicrosoftOffice365Install
{
    public partial class ProductSelectionGUI : Form
    {
        private Configuration _Configuration = new Configuration();

        public ProductSelectionGUI()
        {
            InitializeComponent();

            // Place UAC icon on install button if not running as admin.
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
                UACToButton(installButton, true);

            // Read existing config, if available.
            try
            {
                if (File.Exists(Constants.ConfigFileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Configuration));

                    using (FileStream fs = new FileStream(Constants.ConfigFileName, FileMode.Open))
                    {
                        _Configuration = (Configuration)serializer.Deserialize(fs);
                    }
                }
            } 
            catch
            {
                _Configuration = new Configuration();
            }
            
            if (_Configuration.Add?.Channel == Channel.Volume)
            {
                this.additionalProductsGroup.Text = "Other products:";
                this.toolTip.SetToolTip(this.additionalProductsGroup, null);
                officeLogo.Image = Properties.Resources.Office2019;
                licenceLink.Visible = false;
                this.Text = "Microsoft Office 2019 Installer";
            }

            if (!(_Configuration.Add?.OfficeClientEdition == "32")) {
                _Configuration.Add.OfficeClientEdition = Environment.Is64BitOperatingSystem ? "64" : "32";
            }

            string localSourcePath = Path.Combine(Constants.CurrentDir, "pr", Channel.GetGUID(_Configuration.Add.Channel));
            string localDataFile = Path.Combine(localSourcePath, "Office\\Data", _Configuration.Add.OfficeClientEdition == "64" ? "v64.cab" : "v32.cab");

            if (File.Exists(localDataFile))
            {
                _Configuration.Add.SourcePath = localSourcePath;
                downloadText.Text = "Installation source: " + Constants.CurrentDir;
                downloadText.ForeColor = Color.DarkGreen;
            }
            else if (!String.IsNullOrEmpty(_Configuration.Add.SourcePath))
            {
                if (_Configuration.Add.SourcePath.Last() == '/')
                    _Configuration.Add.SourcePath = _Configuration.Add.SourcePath.Substring(0, _Configuration.Add.SourcePath.Length - 1);

                if (!_Configuration.Add.SourcePath.Contains("/pr/"))
                    _Configuration.Add.SourcePath += "/pr/" + Channel.GetGUID(_Configuration.Add.Channel);

                downloadText.Text = "Installation source: " + _Configuration.Add.SourcePath;
                downloadText.ForeColor = Color.DarkGreen;
            }
            else
            {
                downloadText.Text = "Installation source: officecdn.microsoft.com";
                downloadText.ForeColor = Color.DarkRed;
            }

            if (!String.IsNullOrEmpty(_Configuration?.Updates?.UpdatePath))
            {
                if (_Configuration.Updates.UpdatePath.Last() == '/')
                    _Configuration.Updates.UpdatePath = _Configuration.Updates.UpdatePath.Substring(0, _Configuration.Updates.UpdatePath.Length - 1);

                if (!_Configuration.Updates.UpdatePath.Contains("/pr/"))
                    _Configuration.Updates.UpdatePath += "/pr/" + Channel.GetGUID(_Configuration.Add.Channel);
            }

            this.Text += " (Channel: " + Channel.GetFriendlyChannelName(_Configuration.Add.Channel) + ")";

            // Uncheck apps that have been excluded.
            if (_Configuration.Add?.Product != null)
            {
                foreach (Product product in _Configuration.Add.Product)
                {
                    if (product.ID.Equals(ProductID.VisioPro2019Retail, StringComparison.OrdinalIgnoreCase) ||
                        product.ID.Equals(ProductID.VisioPro2019Volume, StringComparison.OrdinalIgnoreCase))
                    {
                        visioBox.Checked = true;
                    }

                    if (product.ID.Equals(ProductID.ProjectPro2019Retail, StringComparison.OrdinalIgnoreCase) ||
                        product.ID.Equals(ProductID.ProjectPro2019Volume, StringComparison.OrdinalIgnoreCase))
                    {
                        projectBox.Checked = true;
                    }

                    if (product.ExcludeApp != null)
                    {
                        foreach (ExcludeApp excludeApp in _Configuration.Add?.Product?.First()?.ExcludeApp)
                        {
                            if (excludeApp.ID.Equals(AppID.Access, StringComparison.OrdinalIgnoreCase))
                                accessBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.Excel, StringComparison.OrdinalIgnoreCase))
                                excelBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.InfoPath, StringComparison.OrdinalIgnoreCase))
                                infoBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.OneNote, StringComparison.OrdinalIgnoreCase))
                                onenoteBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.Outlook, StringComparison.OrdinalIgnoreCase))
                                outlookBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.PowerPoint, StringComparison.OrdinalIgnoreCase))
                                powerpointBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.Publisher, StringComparison.OrdinalIgnoreCase))
                                publisherBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.SkypeForBusiness, StringComparison.OrdinalIgnoreCase))
                                skypeBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.Teams, StringComparison.OrdinalIgnoreCase))
                                teamsCheckBox.Checked = false;

                            if (excludeApp.ID.Equals(AppID.Word, StringComparison.OrdinalIgnoreCase))
                                wordBox.Checked = false;
                        }
                    }
                }
            }



        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            bool installO365    = false;
            bool volume         = _Configuration.Add.Channel.Equals(Channel.Volume, StringComparison.OrdinalIgnoreCase);

            _Configuration.Add.Product = new List<Product>();

            foreach (Control x in o365ProductGroup.Controls)
            {
                if (x is CheckBox && ((CheckBox)x).Checked)
                {
                    installO365 = true;
                    break;
                }
            }

            if (installO365)
            {
                Product office = new Product() { ID = (volume ? ProductID.ProPlus2019Volume : ProductID.Office365ProPlus) };
                _Configuration.Add.Product.Add(office);
            }

            if (projectBox.Checked)
            {
                Product project = new Product() { ID = (volume ? ProductID.ProjectPro2019Volume : ProductID.ProjectPro2019Retail) };
                _Configuration.Add.Product.Add(project);
            }

            if (visioBox.Checked)
            {
                Product visio = new Product() { ID = (volume ? ProductID.VisioPro2019Volume : ProductID.VisioPro2019Retail) };
                _Configuration.Add.Product.Add(visio);
            }

            if (_Configuration.Add.Product.Count() == 0)
            {
                //ERROR
            }
            else
            {
                foreach (Product product in _Configuration.Add.Product)
                {
                    product.Language = new List<Language>()
                    {
                        new Language() { ID = "en-us" }
                    };
                    product.ExcludeApp = new List<ExcludeApp>();

                    if (!accessBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.Access });

                    if (!excelBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.Excel });

                    if (!infoBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.InfoPath });

                    if (!onenoteBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.OneNote });

                    if (!outlookBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.Outlook });

                    if (!powerpointBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.PowerPoint });

                    if (!publisherBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.Publisher });

                    if (!wordBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.Word });

                    if (!skypeBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.SkypeForBusiness });

                    if (!teamsCheckBox.Checked)
                        product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.Teams });

                    // Exclude OneDrive for Business (It's useless, as the built-in OneDrive in Windows 10 does everything it does and more.)
                    product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.OneDriveForBusiness });

                    // Exclude the Bing for Chrome extension (sets default search to Bing...
                    product.ExcludeApp.Add(new ExcludeApp() { ID = AppID.BingChromeExtension });

                    if (product.ExcludeApp.Count() == 0)
                        product.ExcludeApp = null;
                }


                string configFile = Path.Combine(Constants.TempPath, "configuration.xml");
                if (_Configuration.Save(configFile))
                {
                    // run setup
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                    return;
                }
            }

            this.DialogResult = DialogResult.Yes;
            this.Close();
            return;
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private static void UACToButton(Button button, bool add)
        {
            const Int32 BCM_SETSHIELD = 0x160C;
            if (add)
            {
                // The button must have the flat style
                button.FlatStyle = FlatStyle.System;
                if (button.Text == "")
                    // and it must have text to display the shield
                    button.Text = " ";
                SendMessage(button.Handle, BCM_SETSHIELD, 0, 1);
            }
            else
                SendMessage(button.Handle, BCM_SETSHIELD, 0, 0);
        }

        private void HideTooltip(object sender, EventArgs e)
        {
            toolTip.Hide(this);
        }

        private void infoBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft InfoPath is a software application for designing, distributing, filling and submitting electronic forms containing structured data.",
                this, this.PointToClient(MousePosition));
        }

        private void accessBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft Access is a database management system from Microsoft.",
                this, this.PointToClient(MousePosition));
        }

        private void excelBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft Excel is a spreadsheet editor from Microsoft. It features calculation, graphing tools, pivot tables, and a macro programming language called Visual Basic for Applications.",
                this, this.PointToClient(MousePosition));
        }

        private void onenoteBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft OneNote is a program for free-form information gathering and multi-user collaboration. It gathers users' notes, drawings, screen clippings and audio commentaries. Notes can be shared with other OneNote users over the Internet or a network.",
                this, this.PointToClient(MousePosition));
        }

        private void outlookBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft Outlook is a personal information manager from Microsoft, available as a part of the Microsoft Office suite. Primarily an email application, it also includes a calendar, task manager, contact manager, note taking, journal, and web browsing.",
                this, this.PointToClient(MousePosition));
        }

        private void powerpointBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft PowerPoint is a presentation program, used to create and display slideshows.",
                this, this.PointToClient(MousePosition));
        }

        private void publisherBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft Publisher is a desktop publishing application from Microsoft, differing from Microsoft Word in that the emphasis is placed on page layout and design rather than text composition and proofing.",
                this, this.PointToClient(MousePosition));
        }

        private void wordBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft Word is a word processor developed by Microsoft.",
                this, this.PointToClient(MousePosition));
        }

        private void teamsCheckBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft Teams is a unified communication and collaboration platform that combines persistent workplace chat, video meetings, file storage, and application integration.",
                this, this.PointToClient(MousePosition));
        }

        private void skypeBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Skype for Business is an instant messaging enterprise software.",
                this, this.PointToClient(MousePosition));
        }

        private void visioBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft Visio is a diagramming and vector graphics application and is part of the Microsoft Office family.",
                this, this.PointToClient(MousePosition));
        }

        private void projectBox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Microsoft Project is a project management software product. It is designed to assist a project manager in developing a schedule, assigning resources to tasks, tracking progress, managing the budget, and analyzing workloads.",
                this, this.PointToClient(MousePosition));
        }

        private void licenceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://keys.kurnaicollege.vic.edu.au");
        }
    }
}
