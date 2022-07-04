using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Shotbot
{
    public partial class Loader : MetroFramework.Forms.MetroForm
    {
        private static Random random = new Random();
        public Loader()
        {
            InitializeComponent();
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            this.Text = RandomString(random.Next(10, 20));
            WebClient wc = new WebClient();
            string ver = wc.DownloadString("http://83.229.3.107/shotbot/Version");
            if (ver != Settings.version)
            {
                MessageBox.Show("An update is available! Downloading now...", "Shotbot update");
                //update
                File.Move(AppDomain.CurrentDomain.FriendlyName, "Old.exe");
                wc.DownloadFile("http://83.229.3.107/shotbot/Shotbot.exe", "Shotbot.exe");
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
                //this.Text = "Shotbot Loader [" + Settings.version + "]";
                string foundKey = Whitelisting.Auth.GrabKey();
                if (foundKey != "")
                {
                    keyTextBox.Text = foundKey;
                }
            }
            wc.Dispose(); // No memory leak :)
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Logging you in...";
            //bool isWhitelisted = Whitelisting.Auth.AuthenticateUser();

            if (Whitelisting.Auth.AuthenticateUser())
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
