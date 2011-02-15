using System;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LitJson;

using Microsoft.Win32;

namespace NettivisioHelper
{
    public delegate void dataFetchedDelegate(string fetchedData);
    public partial class mainWindow : Form
    {
        const string jsUrl = "http://www.saunavisio.fi/nettivisio/js/nettivisio.js";
        const string logosUrl = "http://www.saunavisio.fi/nettivisio/images/channellogo/";
        const string playerUrl = "http://www.saunavisio.fi/nettivisio/player.html";
        const string versionUrl = "http://kiinnost.us/nettivisio_helper/latest_version.txt";
        const string vlcArgs = "--one-instance";
        const string programInfoUrl = "http://www.saunavisio.fi/tvrecorder/ajaxprograminfo.sl?";
        public string vlcPath 
        {
            get { return Properties.Settings.Default.vlcPath; }
            set
            {
                Properties.Settings.Default.vlcPath = value;
                Properties.Settings.Default.Save();
            }
        }
        public bool useMulticast
        {
            get { return Properties.Settings.Default.useMulticast; }
            set 
            { 
                useMulticastCheckbox.Checked = value;
            }
        }
        public bool runningOnLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 128);
            }
        }

        public string playerSource;
        Dictionary<string, ChannelData> channels = new Dictionary<string, ChannelData>();

        void fetchChannels(string jsData)
        {
            channelListing.Items.Clear();

            // for storing channel name order
            List<string> channelNames = new List<string>(); 

            Regex dataPatterns = new Regex("(unicast|multicast)\\[\"(.+)\"\\] = \"(.+)\";");
            foreach (Match match in dataPatterns.Matches(jsData))
            {
                GroupCollection groups = match.Groups;
                ChannelData channel;
                if (channels.ContainsKey(groups[2].Value))
                {
                    channel = channels[groups[2].Value];
                }
                else
                {
                    channel = channels[groups[2].Value] = new ChannelData();

                    // so it can first try fetching all channels at once
                    channel.lastUpdatedPrograms = DateTime.Now;

                    channel.name = groups[2].Value;
                    channelNames.Add(channel.name);
                }
                channel.GetType().GetField(groups[1].Value).SetValue(channel, groups[3].Value);
            }

            foreach (string channel in channelNames)
            {
                // TODO find a better way to do this
                if (playerSource.Contains("<li><a href=\"#\">" + channel + "</a></li>"))
                {
                    channelListing.Items.Add(channel);
                }
            }

            // start loading program info for all channels
            WebFetcher.fetchPage(programInfoUrl, fetchAllPrograms);
        }

        void fetchVersion(string versionData)
        {
            Version currentVersion = new Version(Application.ProductVersion);
            Version latestVersion = new Version(versionData);
            if (currentVersion < latestVersion)
            {
                MessageBox.Show("Uusi versio tarjolla osoitteessa http://kiinnost.us/nettivisio_helper/" + Environment.NewLine +
                    "Käyttämäsi versio: " + currentVersion.ToString() + ", uusin versio: " + latestVersion.ToString(), "Päivitys tarjolla");
            }
        }

        void fetchAllPrograms(string rawData)
        {
            // saunalahti program data doesn't have correct json delimeters
            rawData = rawData.Replace(" }", "},");
            rawData = rawData.Substring(0, rawData.LastIndexOf(",")) + "]}";
            JsonData jsonChannels = JsonMapper.ToObject(rawData)["channels"];
            foreach (JsonData jsonChannel in jsonChannels)
            {
                // ugly hack because LitJson can't access the key name
                foreach (ChannelData channel in channels.Values)
                {
                    if (!jsonChannel.ContainsKey(channel.name)) 
                        continue;
                    channel.programs.Clear();
                    channel.programs.AddRange(ProgramData.parse(jsonChannel[0]));
                    updatePrograms(channel);
                }
            }
        }

        void fetchPrograms(string programData, ChannelData channel)
        {
            channel.programs.Clear();
            channel.programs.AddRange(ProgramData.parse(JsonMapper.ToObject(programData)["programs"]));
            updatePrograms(channel);
        }

        void updatePrograms(ChannelData channel)
        {
            if (activeChannel != channel)
            {
                return;
            }
            string programString = "";
            foreach (ProgramData programData in channel.programs)
            {
                programString += programData.startTime.ToString("H:mm") +
                    "-" + programData.endTime.ToString("H:mm") + ": " +
                    programData.name + Environment.NewLine;
            }
            programInfo.Text = programString;
        }

        private ChannelData activeChannel;
        private const int minUpdateDelay = 60;
        void showPrograms(ChannelData channel)
        {
            activeChannel = channel;
            channelName.Text = channel.name;
            updatePrograms(channel);
            if (channel.programs.Count < 5 && DateTime.Now.Subtract(channel.lastUpdatedPrograms).TotalSeconds > minUpdateDelay)
            {
                channel.lastUpdatedPrograms = DateTime.Now;
                programInfo.Text += "Ladataan ohjelmatietoja...";
                WebFetcher.fetchPage(programInfoUrl + "channel=" + Uri.EscapeUriString(channel.name), delegate(string result)
                {
                    fetchPrograms(result, channel);
                });
            }
        }
  
        private void programsTimer_Tick(object sender, EventArgs e)
        {
            if (activeChannel != null)
            {
                showPrograms(activeChannel);
            }
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            WebFetcher.mainWindow = this;
            if (Properties.Settings.Default.hasWindowPos)
            {
                this.Location = Properties.Settings.Default.windowPos;
                Rectangle screenBounds = System.Windows.Forms.Screen.GetBounds(this);
                if ((this.Top < screenBounds.Top) || ((this.Top + this.Height) > (screenBounds.Top + screenBounds.Height))) {
                    this.Top = screenBounds.Top;
                }
                if ((this.Left < screenBounds.Left) || ((this.Left + this.Width) > (screenBounds.Left + screenBounds.Width)))
                {
                    this.Left = screenBounds.Left;
                }
            }
            if (vlcPath.Length == 0 || !File.Exists(vlcPath))
            {
                vlcPath = Utils.getVlcPath();
            }
            vlcPathTextbox.Text = vlcPath;
            tabHolder.SelectTab(Properties.Settings.Default.hasWindowPos ? 0 : 1);
            aboutLabel.Text = "Versio " + Application.ProductVersion + Environment.NewLine +
                "Tehnyt Antti Risteli" + Environment.NewLine +
                "antti@kiinnost.us";
        }

        private void mainWindow_Shown(object sender, EventArgs e)
        {
            WebFetcher.fetchPage(playerUrl, delegate(string data) {
                playerSource = data;
                WebFetcher.fetchPage(jsUrl, fetchChannels);
            });

            if (Properties.Settings.Default.checkForUpdates)
            {
                WebFetcher.fetchPage(versionUrl, fetchVersion);
            }
            if (deinterlaceComboBox.SelectedIndex == -1)
                deinterlaceComboBox.SelectedIndex = 0;
        }

        private void mainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.hasWindowPos = true;
            Properties.Settings.Default.windowPos = new Point(this.Left, this.Top);
            Properties.Settings.Default.Save();
        }

        public mainWindow()
        {
            InitializeComponent();
        }

        private String constructArguments(ChannelData channel)
        {
            StringBuilder sb = new StringBuilder();
            if (!runningOnLinux)
                sb.Append(vlcArgs + " ");
            if (Properties.Settings.Default.useDeinterlacing)
                sb.Append("--vout-filter=deinterlace --deinterlace-mode=" + Properties.Settings.Default.deinterlacingMode.ToLower() + " ");
            sb.Append(useMulticast ? channel.multicast : channel.unicast);
            return sb.ToString();
        }

        private System.Diagnostics.Process lastStartedProcess;
        private void watchButton_Click(object sender, EventArgs e)
        {
            if (channelListing.SelectedItem != null)
            {
                ChannelData channel = channels[(string)channelListing.SelectedItem];
                if (lastStartedProcess != null && runningOnLinux)
                {
                    try
                    {
                        if (!lastStartedProcess.HasExited)
                        {
                            lastStartedProcess.Kill();
                        }
                    } catch (Exception) {
                    }
                }
                try
                {
                    lastStartedProcess = System.Diagnostics.Process.Start(vlcPath, constructArguments(channel));
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("VLC:n käynnistäminen epäonnistui. Varmista että VLC:n sijainti on oikea.", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chooseManuallyButton_Click(object sender, EventArgs e)
        {
            // ask the user
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Valitse vlc.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                vlcPath = openFileDialog.FileName;
            }
        }

        private void runAutoButton_Click(object sender, EventArgs e)
        {
            string path = Utils.getVlcPath();

            if (path.Length > 0 && File.Exists(path))
            {
                vlcPath = path;
            }
            else
            {
                MessageBox.Show("Automaattinen haku ei löytänyt VLC:tä", "Haku");
            }
        }

        private void channelListing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (channelListing.SelectedItem != null && channels.ContainsKey((string)channelListing.SelectedItem))
            {
                ChannelData channel = channels[(string)channelListing.SelectedItem];
                programPanel.VerticalScroll.Value = programPanel.VerticalScroll.Minimum;
                showPrograms(channel);
            }
        }

        private ScrollPanelMessageFilter filter;
        private void mainWindow_Activated(object sender, EventArgs e)
        {
            // ScrollPanelMessageFilter doesn't work with Mono (atleast on Linux)
            if (!runningOnLinux)
            {
                filter = new ScrollPanelMessageFilter(programPanel);
                Application.AddMessageFilter(filter);
            }
        }

        private void mainWindow_Deactivate(object sender, EventArgs e)
        {
            if (!runningOnLinux)
            {
                Application.RemoveMessageFilter(filter);
            }
        }
    }

    #region WebFetcher class
    public class WebFetcher
    {
        private static readonly WebFetcher instance = new WebFetcher();
        private WebFetcher(){}
        public static mainWindow mainWindow;

        void stringRequestReady(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //TODO do some real handling
                return;
            }
            
            mainWindow.Invoke((Delegate)e.UserState, new object[] { e.Result });
            ((WebClient)sender).Dispose();
        }

        public static void fetchPage(string url, dataFetchedDelegate handler)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += instance.stringRequestReady;
            webClient.DownloadStringAsync(new Uri(url), handler);
        }
    }
    #endregion

    #region ProgramData class
    public class ProgramData
    {
        public int id;
        public string name;
        public DateTime startTime;
        public DateTime endTime;

        public Boolean isOver()
        {
            return DateTime.Now > endTime;
        }

        private static IFormatProvider dateFormat = new System.Globalization.CultureInfo("fi-FI", true);
        public static List<ProgramData> parse(JsonData programsData)
        {
            List<ProgramData> programs = new List<ProgramData>();
            foreach (JsonData curData in programsData)
            {
                ProgramData programData = new ProgramData();
                programData.id = int.Parse((string)curData["id"]);
                programData.name = Uri.UnescapeDataString((string)curData["name"]);
                programData.startTime = DateTime.Parse((string)curData["start_time"], dateFormat);
                programData.endTime = DateTime.Parse((string)curData["end_time"], dateFormat);
                programs.Add(programData);
            }

            return programs;
        }
    }
    #endregion

    #region ChannelData class
    public class ChannelData
    {
        public List<ProgramData> programs {
            get {
                deleteEndedPrograms();
                return programsPrivate; 
            }
        }

        private void deleteEndedPrograms()
        {
            programsPrivate.RemoveAll(delegate(ProgramData programData)
            {
                return programData.isOver();
            });
        }

        private List<ProgramData> programsPrivate = new List<ProgramData>();
        public DateTime lastUpdatedPrograms = new DateTime(0);
        public string name;
        public string unicast;
        public string multicast;
    }
    #endregion

    #region Utils class
    public class Utils
    {
        private const string vlcRegistryKey = "SOFTWARE\\VideoLAN\\VLC";
        public static string getVlcPath()
        {
            // try registry
            RegistryKey[] keys = new RegistryKey[] { Registry.LocalMachine, Registry.CurrentUser };
            foreach (RegistryKey rootKey in keys)
            {
                try {
                    RegistryKey key = rootKey.OpenSubKey(vlcRegistryKey);
                    if (key != null)
                    {
                        string fileName = (string)key.GetValue("");
                        if (File.Exists(fileName))
                        {
                            return fileName;
                        }
                    }
                } catch (Exception) {
                    // ignore _any_ exceptions, this isn't supposed to inform
                    // the user about them
                }
            }

            return "";
        }
    }
    #endregion
}