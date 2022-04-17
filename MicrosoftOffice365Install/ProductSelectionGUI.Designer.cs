namespace MicrosoftOffice365Install
{
    partial class ProductSelectionGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductSelectionGUI));
            this.officeLogo = new System.Windows.Forms.PictureBox();
            this.o365ProductGroup = new System.Windows.Forms.GroupBox();
            this.teamsCheckBox = new System.Windows.Forms.CheckBox();
            this.skypeBox = new System.Windows.Forms.CheckBox();
            this.wordBox = new System.Windows.Forms.CheckBox();
            this.publisherBox = new System.Windows.Forms.CheckBox();
            this.powerpointBox = new System.Windows.Forms.CheckBox();
            this.outlookBox = new System.Windows.Forms.CheckBox();
            this.onenoteBox = new System.Windows.Forms.CheckBox();
            this.infoBox = new System.Windows.Forms.CheckBox();
            this.excelBox = new System.Windows.Forms.CheckBox();
            this.accessBox = new System.Windows.Forms.CheckBox();
            this.installButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.downloadText = new System.Windows.Forms.Label();
            this.additionalProductsGroup = new System.Windows.Forms.GroupBox();
            this.licenceLink = new System.Windows.Forms.LinkLabel();
            this.projectBox = new System.Windows.Forms.CheckBox();
            this.visioBox = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.officeLogo)).BeginInit();
            this.o365ProductGroup.SuspendLayout();
            this.additionalProductsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // officeLogo
            // 
            this.officeLogo.Image = ((System.Drawing.Image)(resources.GetObject("officeLogo.Image")));
            this.officeLogo.Location = new System.Drawing.Point(45, 12);
            this.officeLogo.Name = "officeLogo";
            this.officeLogo.Size = new System.Drawing.Size(303, 69);
            this.officeLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.officeLogo.TabIndex = 0;
            this.officeLogo.TabStop = false;
            // 
            // o365ProductGroup
            // 
            this.o365ProductGroup.Controls.Add(this.teamsCheckBox);
            this.o365ProductGroup.Controls.Add(this.skypeBox);
            this.o365ProductGroup.Controls.Add(this.wordBox);
            this.o365ProductGroup.Controls.Add(this.publisherBox);
            this.o365ProductGroup.Controls.Add(this.powerpointBox);
            this.o365ProductGroup.Controls.Add(this.outlookBox);
            this.o365ProductGroup.Controls.Add(this.onenoteBox);
            this.o365ProductGroup.Controls.Add(this.infoBox);
            this.o365ProductGroup.Controls.Add(this.excelBox);
            this.o365ProductGroup.Controls.Add(this.accessBox);
            this.o365ProductGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o365ProductGroup.Location = new System.Drawing.Point(12, 101);
            this.o365ProductGroup.Name = "o365ProductGroup";
            this.o365ProductGroup.Size = new System.Drawing.Size(375, 199);
            this.o365ProductGroup.TabIndex = 1;
            this.o365ProductGroup.TabStop = false;
            this.o365ProductGroup.Text = "Please select the components that you wish to install:";
            // 
            // teamsCheckBox
            // 
            this.teamsCheckBox.AutoSize = true;
            this.teamsCheckBox.Checked = true;
            this.teamsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.teamsCheckBox.Location = new System.Drawing.Point(181, 123);
            this.teamsCheckBox.Name = "teamsCheckBox";
            this.teamsCheckBox.Size = new System.Drawing.Size(137, 24);
            this.teamsCheckBox.TabIndex = 10;
            this.teamsCheckBox.Text = "Microsoft Teams";
            this.teamsCheckBox.UseVisualStyleBackColor = true;
            this.teamsCheckBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.teamsCheckBox.MouseHover += new System.EventHandler(this.teamsCheckBox_MouseHover);
            // 
            // skypeBox
            // 
            this.skypeBox.AutoSize = true;
            this.skypeBox.Checked = true;
            this.skypeBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skypeBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skypeBox.Location = new System.Drawing.Point(181, 153);
            this.skypeBox.Name = "skypeBox";
            this.skypeBox.Size = new System.Drawing.Size(149, 24);
            this.skypeBox.TabIndex = 9;
            this.skypeBox.Text = "Skype for Business";
            this.skypeBox.UseVisualStyleBackColor = true;
            this.skypeBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.skypeBox.MouseHover += new System.EventHandler(this.skypeBox_MouseHover);
            // 
            // wordBox
            // 
            this.wordBox.AutoSize = true;
            this.wordBox.Checked = true;
            this.wordBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wordBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordBox.Location = new System.Drawing.Point(181, 93);
            this.wordBox.Name = "wordBox";
            this.wordBox.Size = new System.Drawing.Size(64, 24);
            this.wordBox.TabIndex = 7;
            this.wordBox.Text = "Word";
            this.wordBox.UseVisualStyleBackColor = true;
            this.wordBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.wordBox.MouseHover += new System.EventHandler(this.wordBox_MouseHover);
            // 
            // publisherBox
            // 
            this.publisherBox.AutoSize = true;
            this.publisherBox.Checked = true;
            this.publisherBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.publisherBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publisherBox.Location = new System.Drawing.Point(181, 63);
            this.publisherBox.Name = "publisherBox";
            this.publisherBox.Size = new System.Drawing.Size(88, 24);
            this.publisherBox.TabIndex = 6;
            this.publisherBox.Text = "Publisher";
            this.publisherBox.UseVisualStyleBackColor = true;
            this.publisherBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.publisherBox.MouseHover += new System.EventHandler(this.publisherBox_MouseHover);
            // 
            // powerpointBox
            // 
            this.powerpointBox.AutoSize = true;
            this.powerpointBox.Checked = true;
            this.powerpointBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.powerpointBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerpointBox.Location = new System.Drawing.Point(181, 33);
            this.powerpointBox.Name = "powerpointBox";
            this.powerpointBox.Size = new System.Drawing.Size(101, 24);
            this.powerpointBox.TabIndex = 5;
            this.powerpointBox.Text = "PowerPoint";
            this.powerpointBox.UseVisualStyleBackColor = true;
            this.powerpointBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.powerpointBox.MouseHover += new System.EventHandler(this.powerpointBox_MouseHover);
            // 
            // outlookBox
            // 
            this.outlookBox.AutoSize = true;
            this.outlookBox.Checked = true;
            this.outlookBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.outlookBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outlookBox.Location = new System.Drawing.Point(32, 153);
            this.outlookBox.Name = "outlookBox";
            this.outlookBox.Size = new System.Drawing.Size(81, 24);
            this.outlookBox.TabIndex = 4;
            this.outlookBox.Text = "Outlook";
            this.outlookBox.UseVisualStyleBackColor = true;
            this.outlookBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.outlookBox.MouseHover += new System.EventHandler(this.outlookBox_MouseHover);
            // 
            // onenoteBox
            // 
            this.onenoteBox.AutoSize = true;
            this.onenoteBox.Checked = true;
            this.onenoteBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onenoteBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onenoteBox.Location = new System.Drawing.Point(32, 123);
            this.onenoteBox.Name = "onenoteBox";
            this.onenoteBox.Size = new System.Drawing.Size(88, 24);
            this.onenoteBox.TabIndex = 3;
            this.onenoteBox.Text = "OneNote";
            this.onenoteBox.UseVisualStyleBackColor = true;
            this.onenoteBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.onenoteBox.MouseHover += new System.EventHandler(this.onenoteBox_MouseHover);
            // 
            // infoBox
            // 
            this.infoBox.AutoSize = true;
            this.infoBox.Checked = true;
            this.infoBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.infoBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Location = new System.Drawing.Point(32, 93);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(82, 24);
            this.infoBox.TabIndex = 2;
            this.infoBox.Text = "InfoPath";
            this.infoBox.UseVisualStyleBackColor = true;
            this.infoBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.infoBox.MouseHover += new System.EventHandler(this.infoBox_MouseHover);
            // 
            // excelBox
            // 
            this.excelBox.AutoSize = true;
            this.excelBox.Checked = true;
            this.excelBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.excelBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelBox.Location = new System.Drawing.Point(33, 63);
            this.excelBox.Name = "excelBox";
            this.excelBox.Size = new System.Drawing.Size(62, 24);
            this.excelBox.TabIndex = 1;
            this.excelBox.Text = "Excel";
            this.excelBox.UseVisualStyleBackColor = true;
            this.excelBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.excelBox.MouseHover += new System.EventHandler(this.excelBox_MouseHover);
            // 
            // accessBox
            // 
            this.accessBox.AutoSize = true;
            this.accessBox.Checked = true;
            this.accessBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.accessBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accessBox.Location = new System.Drawing.Point(33, 33);
            this.accessBox.Name = "accessBox";
            this.accessBox.Size = new System.Drawing.Size(72, 24);
            this.accessBox.TabIndex = 0;
            this.accessBox.Text = "Access";
            this.accessBox.UseVisualStyleBackColor = true;
            this.accessBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.accessBox.MouseHover += new System.EventHandler(this.accessBox_MouseHover);
            // 
            // installButton
            // 
            this.installButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.installButton.Location = new System.Drawing.Point(231, 418);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 2;
            this.installButton.Text = " &Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(312, 418);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "E&xit";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // downloadText
            // 
            this.downloadText.AutoEllipsis = true;
            this.downloadText.AutoSize = true;
            this.downloadText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.downloadText.Location = new System.Drawing.Point(9, 397);
            this.downloadText.MaximumSize = new System.Drawing.Size(375, 13);
            this.downloadText.Name = "downloadText";
            this.downloadText.Size = new System.Drawing.Size(58, 13);
            this.downloadText.TabIndex = 4;
            this.downloadText.Text = "Loading...";
            // 
            // additionalProductsGroup
            // 
            this.additionalProductsGroup.Controls.Add(this.licenceLink);
            this.additionalProductsGroup.Controls.Add(this.projectBox);
            this.additionalProductsGroup.Controls.Add(this.visioBox);
            this.additionalProductsGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.additionalProductsGroup.Location = new System.Drawing.Point(12, 306);
            this.additionalProductsGroup.Name = "additionalProductsGroup";
            this.additionalProductsGroup.Size = new System.Drawing.Size(375, 88);
            this.additionalProductsGroup.TabIndex = 5;
            this.additionalProductsGroup.TabStop = false;
            this.additionalProductsGroup.Text = "Other products (requires additional licences):";
            this.toolTip.SetToolTip(this.additionalProductsGroup, "These products are not included in Office 365, and require a product key from Azu" +
        "re DevTools.");
            // 
            // licenceLink
            // 
            this.licenceLink.AutoSize = true;
            this.licenceLink.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.licenceLink.Location = new System.Drawing.Point(108, 63);
            this.licenceLink.Name = "licenceLink";
            this.licenceLink.Size = new System.Drawing.Size(151, 13);
            this.licenceLink.TabIndex = 2;
            this.licenceLink.TabStop = true;
            this.licenceLink.Text = "Click here to get your key(s).";
            this.licenceLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.licenceLink_LinkClicked);
            // 
            // projectBox
            // 
            this.projectBox.AutoSize = true;
            this.projectBox.Location = new System.Drawing.Point(181, 27);
            this.projectBox.Name = "projectBox";
            this.projectBox.Size = new System.Drawing.Size(146, 24);
            this.projectBox.TabIndex = 1;
            this.projectBox.Text = "Project Pro (2019)";
            this.projectBox.UseVisualStyleBackColor = true;
            this.projectBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.projectBox.MouseHover += new System.EventHandler(this.projectBox_MouseHover);
            // 
            // visioBox
            // 
            this.visioBox.AutoSize = true;
            this.visioBox.Location = new System.Drawing.Point(32, 27);
            this.visioBox.Name = "visioBox";
            this.visioBox.Size = new System.Drawing.Size(132, 24);
            this.visioBox.TabIndex = 0;
            this.visioBox.Text = "Visio Pro (2019)";
            this.visioBox.UseVisualStyleBackColor = true;
            this.visioBox.MouseLeave += new System.EventHandler(this.HideTooltip);
            this.visioBox.MouseHover += new System.EventHandler(this.visioBox_MouseHover);
            // 
            // ProductSelectionGUI
            // 
            this.AcceptButton = this.installButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(399, 453);
            this.Controls.Add(this.additionalProductsGroup);
            this.Controls.Add(this.downloadText);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.o365ProductGroup);
            this.Controls.Add(this.officeLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductSelectionGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Microsoft Office 365 Installer";
            ((System.ComponentModel.ISupportInitialize)(this.officeLogo)).EndInit();
            this.o365ProductGroup.ResumeLayout(false);
            this.o365ProductGroup.PerformLayout();
            this.additionalProductsGroup.ResumeLayout(false);
            this.additionalProductsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox officeLogo;
        private System.Windows.Forms.GroupBox o365ProductGroup;
        private System.Windows.Forms.CheckBox skypeBox;
        private System.Windows.Forms.CheckBox wordBox;
        private System.Windows.Forms.CheckBox publisherBox;
        private System.Windows.Forms.CheckBox powerpointBox;
        private System.Windows.Forms.CheckBox outlookBox;
        private System.Windows.Forms.CheckBox onenoteBox;
        private System.Windows.Forms.CheckBox infoBox;
        private System.Windows.Forms.CheckBox excelBox;
        private System.Windows.Forms.CheckBox accessBox;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label downloadText;
        private System.Windows.Forms.GroupBox additionalProductsGroup;
        private System.Windows.Forms.CheckBox projectBox;
        private System.Windows.Forms.CheckBox visioBox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox teamsCheckBox;
        private System.Windows.Forms.LinkLabel licenceLink;
    }
}