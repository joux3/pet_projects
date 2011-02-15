namespace NettivisioHelper
{
    partial class mainWindow
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
            System.Windows.Forms.TabPage channelPage;
            System.Windows.Forms.TabPage settingsPage;
            System.Windows.Forms.GroupBox vlcPathPanel;
            System.Windows.Forms.Button chooseManuallyButton;
            System.Windows.Forms.Button runAutoButton;
            this.programPanel = new System.Windows.Forms.Panel();
            this.programInfo = new System.Windows.Forms.Label();
            this.watchButton = new System.Windows.Forms.Button();
            this.channelName = new System.Windows.Forms.Label();
            this.channelListing = new System.Windows.Forms.ListBox();
            this.deinterlacingCheckBox = new System.Windows.Forms.CheckBox();
            this.deinterlaceComboBox = new System.Windows.Forms.ComboBox();
            this.checkForUpdatesCheckbox = new System.Windows.Forms.CheckBox();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.vlcPathTextbox = new System.Windows.Forms.TextBox();
            this.useMulticastCheckbox = new System.Windows.Forms.CheckBox();
            this.tabHolder = new System.Windows.Forms.TabControl();
            this.programsTimer = new System.Windows.Forms.Timer(this.components);
            channelPage = new System.Windows.Forms.TabPage();
            settingsPage = new System.Windows.Forms.TabPage();
            vlcPathPanel = new System.Windows.Forms.GroupBox();
            chooseManuallyButton = new System.Windows.Forms.Button();
            runAutoButton = new System.Windows.Forms.Button();
            channelPage.SuspendLayout();
            this.programPanel.SuspendLayout();
            settingsPage.SuspendLayout();
            vlcPathPanel.SuspendLayout();
            this.tabHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // channelPage
            // 
            channelPage.Controls.Add(this.programPanel);
            channelPage.Controls.Add(this.watchButton);
            channelPage.Controls.Add(this.channelName);
            channelPage.Controls.Add(this.channelListing);
            channelPage.Location = new System.Drawing.Point(4, 22);
            channelPage.Name = "channelPage";
            channelPage.Padding = new System.Windows.Forms.Padding(3);
            channelPage.Size = new System.Drawing.Size(342, 236);
            channelPage.TabIndex = 0;
            channelPage.Text = "Kanavat";
            channelPage.UseVisualStyleBackColor = true;
            // 
            // programPanel
            // 
            this.programPanel.AutoScroll = true;
            this.programPanel.Controls.Add(this.programInfo);
            this.programPanel.Location = new System.Drawing.Point(116, 33);
            this.programPanel.Name = "programPanel";
            this.programPanel.Size = new System.Drawing.Size(218, 195);
            this.programPanel.TabIndex = 4;
            // 
            // programInfo
            // 
            this.programInfo.AutoSize = true;
            this.programInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.programInfo.Location = new System.Drawing.Point(3, 0);
            this.programInfo.MaximumSize = new System.Drawing.Size(195, 0);
            this.programInfo.MinimumSize = new System.Drawing.Size(195, 0);
            this.programInfo.Name = "programInfo";
            this.programInfo.Size = new System.Drawing.Size(195, 13);
            this.programInfo.TabIndex = 3;
            this.programInfo.UseMnemonic = false;
            // 
            // watchButton
            // 
            this.watchButton.Location = new System.Drawing.Point(6, 202);
            this.watchButton.Name = "watchButton";
            this.watchButton.Size = new System.Drawing.Size(104, 27);
            this.watchButton.TabIndex = 1;
            this.watchButton.Text = "Avaa kanava";
            this.watchButton.UseVisualStyleBackColor = true;
            this.watchButton.Click += new System.EventHandler(this.watchButton_Click);
            // 
            // channelName
            // 
            this.channelName.AutoSize = true;
            this.channelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelName.Location = new System.Drawing.Point(118, 10);
            this.channelName.Name = "channelName";
            this.channelName.Size = new System.Drawing.Size(0, 20);
            this.channelName.TabIndex = 2;
            // 
            // channelListing
            // 
            this.channelListing.FormattingEnabled = true;
            this.channelListing.IntegralHeight = false;
            this.channelListing.Items.AddRange(new object[] {
            "Ladataan kanavia..."});
            this.channelListing.Location = new System.Drawing.Point(6, 10);
            this.channelListing.Name = "channelListing";
            this.channelListing.Size = new System.Drawing.Size(104, 186);
            this.channelListing.TabIndex = 0;
            this.channelListing.SelectedIndexChanged += new System.EventHandler(this.channelListing_SelectedIndexChanged);
            // 
            // settingsPage
            // 
            settingsPage.Controls.Add(this.deinterlacingCheckBox);
            settingsPage.Controls.Add(this.deinterlaceComboBox);
            settingsPage.Controls.Add(this.checkForUpdatesCheckbox);
            settingsPage.Controls.Add(this.aboutLabel);
            settingsPage.Controls.Add(vlcPathPanel);
            settingsPage.Controls.Add(this.useMulticastCheckbox);
            settingsPage.Location = new System.Drawing.Point(4, 22);
            settingsPage.Name = "settingsPage";
            settingsPage.Padding = new System.Windows.Forms.Padding(3);
            settingsPage.Size = new System.Drawing.Size(342, 236);
            settingsPage.TabIndex = 1;
            settingsPage.Text = "Asetukset";
            settingsPage.UseVisualStyleBackColor = true;
            // 
            // deinterlacingCheckBox
            // 
            this.deinterlacingCheckBox.AutoSize = true;
            this.deinterlacingCheckBox.Checked = global::NettivisioHelper.Properties.Settings.Default.useDeinterlacing;
            this.deinterlacingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::NettivisioHelper.Properties.Settings.Default, "useDeinterlacing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.deinterlacingCheckBox.Location = new System.Drawing.Point(8, 94);
            this.deinterlacingCheckBox.Name = "deinterlacingCheckBox";
            this.deinterlacingCheckBox.Size = new System.Drawing.Size(111, 17);
            this.deinterlacingCheckBox.TabIndex = 6;
            this.deinterlacingCheckBox.Text = "Lomituksenpoisto:";
            this.deinterlacingCheckBox.UseVisualStyleBackColor = true;
            // 
            // deinterlaceComboBox
            // 
            this.deinterlaceComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::NettivisioHelper.Properties.Settings.Default, "deinterlacingMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.deinterlaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deinterlaceComboBox.FormattingEnabled = true;
            this.deinterlaceComboBox.Items.AddRange(new object[] {
            "Discard",
            "Blend",
            "Mean",
            "Bob",
            "Linear",
            "X"});
            this.deinterlaceComboBox.Location = new System.Drawing.Point(119, 92);
            this.deinterlaceComboBox.Name = "deinterlaceComboBox";
            this.deinterlaceComboBox.Size = new System.Drawing.Size(217, 21);
            this.deinterlaceComboBox.TabIndex = 4;
            this.deinterlaceComboBox.Text = global::NettivisioHelper.Properties.Settings.Default.deinterlacingMode;
            // 
            // checkForUpdatesCheckbox
            // 
            this.checkForUpdatesCheckbox.AutoSize = true;
            this.checkForUpdatesCheckbox.Checked = global::NettivisioHelper.Properties.Settings.Default.checkForUpdates;
            this.checkForUpdatesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkForUpdatesCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::NettivisioHelper.Properties.Settings.Default, "checkForUpdates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkForUpdatesCheckbox.Location = new System.Drawing.Point(8, 211);
            this.checkForUpdatesCheckbox.Name = "checkForUpdatesCheckbox";
            this.checkForUpdatesCheckbox.Size = new System.Drawing.Size(187, 17);
            this.checkForUpdatesCheckbox.TabIndex = 3;
            this.checkForUpdatesCheckbox.Text = "Tarkista päivitykset käynnistäessä";
            this.checkForUpdatesCheckbox.UseVisualStyleBackColor = true;
            // 
            // aboutLabel
            // 
            this.aboutLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.aboutLabel.Location = new System.Drawing.Point(114, 192);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(225, 41);
            this.aboutLabel.TabIndex = 2;
            this.aboutLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // vlcPathPanel
            // 
            vlcPathPanel.Controls.Add(chooseManuallyButton);
            vlcPathPanel.Controls.Add(runAutoButton);
            vlcPathPanel.Controls.Add(this.vlcPathTextbox);
            vlcPathPanel.Location = new System.Drawing.Point(8, 6);
            vlcPathPanel.Name = "vlcPathPanel";
            vlcPathPanel.Size = new System.Drawing.Size(328, 80);
            vlcPathPanel.TabIndex = 1;
            vlcPathPanel.TabStop = false;
            vlcPathPanel.Text = "VLC:n sijainti";
            // 
            // chooseManuallyButton
            // 
            chooseManuallyButton.Location = new System.Drawing.Point(227, 45);
            chooseManuallyButton.Name = "chooseManuallyButton";
            chooseManuallyButton.Size = new System.Drawing.Size(95, 27);
            chooseManuallyButton.TabIndex = 1;
            chooseManuallyButton.Text = "Valitse käsin";
            chooseManuallyButton.UseVisualStyleBackColor = true;
            chooseManuallyButton.Click += new System.EventHandler(this.chooseManuallyButton_Click);
            // 
            // runAutoButton
            // 
            runAutoButton.Location = new System.Drawing.Point(106, 45);
            runAutoButton.Name = "runAutoButton";
            runAutoButton.Size = new System.Drawing.Size(115, 27);
            runAutoButton.TabIndex = 2;
            runAutoButton.Text = "Hae automaattisesti";
            runAutoButton.UseVisualStyleBackColor = true;
            runAutoButton.Click += new System.EventHandler(this.runAutoButton_Click);
            // 
            // vlcPathTextbox
            // 
            this.vlcPathTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::NettivisioHelper.Properties.Settings.Default, "vlcPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vlcPathTextbox.Location = new System.Drawing.Point(6, 19);
            this.vlcPathTextbox.Name = "vlcPathTextbox";
            this.vlcPathTextbox.Size = new System.Drawing.Size(316, 20);
            this.vlcPathTextbox.TabIndex = 0;
            this.vlcPathTextbox.Text = global::NettivisioHelper.Properties.Settings.Default.vlcPath;
            // 
            // useMulticastCheckbox
            // 
            this.useMulticastCheckbox.AutoSize = true;
            this.useMulticastCheckbox.Checked = global::NettivisioHelper.Properties.Settings.Default.useMulticast;
            this.useMulticastCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useMulticastCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::NettivisioHelper.Properties.Settings.Default, "useMulticast", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useMulticastCheckbox.Location = new System.Drawing.Point(8, 188);
            this.useMulticastCheckbox.Name = "useMulticastCheckbox";
            this.useMulticastCheckbox.Size = new System.Drawing.Size(105, 17);
            this.useMulticastCheckbox.TabIndex = 0;
            this.useMulticastCheckbox.Text = "Käytä multicastia";
            this.useMulticastCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabHolder
            // 
            this.tabHolder.Controls.Add(channelPage);
            this.tabHolder.Controls.Add(settingsPage);
            this.tabHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHolder.Location = new System.Drawing.Point(0, 0);
            this.tabHolder.Name = "tabHolder";
            this.tabHolder.SelectedIndex = 0;
            this.tabHolder.Size = new System.Drawing.Size(350, 262);
            this.tabHolder.TabIndex = 4;
            // 
            // programsTimer
            // 
            this.programsTimer.Enabled = true;
            this.programsTimer.Interval = 1000;
            this.programsTimer.Tick += new System.EventHandler(this.programsTimer_Tick);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 262);
            this.Controls.Add(this.tabHolder);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nettivisio helper";
            this.Deactivate += new System.EventHandler(this.mainWindow_Deactivate);
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.Shown += new System.EventHandler(this.mainWindow_Shown);
            this.Activated += new System.EventHandler(this.mainWindow_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainWindow_FormClosed);
            channelPage.ResumeLayout(false);
            channelPage.PerformLayout();
            this.programPanel.ResumeLayout(false);
            this.programPanel.PerformLayout();
            settingsPage.ResumeLayout(false);
            settingsPage.PerformLayout();
            vlcPathPanel.ResumeLayout(false);
            vlcPathPanel.PerformLayout();
            this.tabHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button watchButton;
        private System.Windows.Forms.ListBox channelListing;
        private System.Windows.Forms.Label channelName;
        private System.Windows.Forms.Label programInfo;
        private System.Windows.Forms.CheckBox useMulticastCheckbox;
        private System.Windows.Forms.TextBox vlcPathTextbox;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.CheckBox checkForUpdatesCheckbox;
        private System.Windows.Forms.Timer programsTimer;
        private System.Windows.Forms.TabControl tabHolder;
        private System.Windows.Forms.Panel programPanel;
        private System.Windows.Forms.ComboBox deinterlaceComboBox;
        private System.Windows.Forms.CheckBox deinterlacingCheckBox;



    }
}

