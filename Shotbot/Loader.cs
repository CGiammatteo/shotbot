using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Shotbot
{
    public partial class Loader : MetroFramework.Forms.MetroForm
    {
        public Loader()
        {
            InitializeComponent();
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string ver = wc.DownloadString("http://34.230.44.28/shotbot/Version");
            if (ver != Settings.version)
            {
                MessageBox.Show("An update is available! Downloading now...", "Shotbot update");
                //update
                File.Move(AppDomain.CurrentDomain.FriendlyName, "Old.exe");
                wc.DownloadFile("http://34.230.44.28/shotbot/Shotbot.exe", "Shotbot.exe");
                Process.Start(@"Shotbot.exe");
                Application.Exit();
            }
            else
            {
                if (File.Exists(@"Old.exe"))
                {
                    File.Delete(@"Old.exe");
                }
                //is up to date
                this.Text = "Shotbot Loader [" + Settings.version + "]";
                string foundKey = Whitelisting.Auth.GrabKey();
                if (foundKey != "")
                {
                    keyTextBox.Text = foundKey;
                    keyTextBox.ReadOnly = true;
                }
            }
            wc.Dispose(); // No memory leak :)
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Logging you in...";
            bool isWhitelisted = Whitelisting.Auth.AuthenticateUser();

            if (isWhitelisted)
            {
                var mainUi = new ValMain();
                mainUi.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not whitelisted!", "Shotbot Whitelist");
                Environment.Exit(0);
            }
        }

        private void activateButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Whitelisting your account...";

            bool worked = Whitelisting.Auth.WhitelistUser(keyTextBox.Text.ToString());

            if (worked)
            {
                MessageBox.Show("You have been whitelisted! Reopen the program to continue.", "Shotbox Whitelist");
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Unable to whitelist your account!", "Shotbox Whitelist");
                Environment.Exit(0);
            }
        }
    }
}
