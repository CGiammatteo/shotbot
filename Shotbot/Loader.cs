using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using System.Web;

namespace Shotbot
{
    public partial class Loader : MetroFramework.Forms.MetroForm
    {
        public Loader()
        {
            InitializeComponent();
           
        }

        
        
        private async void Loader_Load(object sender, EventArgs e)
        {
            // File Check
            if (File.Exists("Shotbot_Old.exe"))
            {
                // Found
                File.Delete("Shotbot_Old.exe");
            }else if (AppDomain.CurrentDomain.FriendlyName == "Shotbot_Old.exe")
            {
                Process.Start("Shotbot.exe");
                Application.Exit();
            }

            // Update Check
            WebClient client = new WebClient();
           
            string Version = "1.0.0.1";
            string OnlineVersion = client.DownloadString("https://pastebin.com/raw/GTyapBah");

            if (Version == OnlineVersion)
            {
                // Good
            }
            else
            {
                // Let them know
                MessageBox.Show($"Update Found! {OnlineVersion}","Shotbot Updater");
                File.Move(AppDomain.CurrentDomain.FriendlyName, "Shotbot_Old.exe");
                // Download
                Uri DownloadPlace = new Uri("https://gostdud.000webhostapp.com/Shotbot.exe");
                client.DownloadFileAsync(DownloadPlace, "Shotbot.exe");
                Process.Start("Shotbot.exe");
                Application.Exit();

            }

            string foundKey = Whitelisting.Auth.GrabKey();
            if (foundKey != "")
            {
                keyTextBox.Text = foundKey;
                keyTextBox.ReadOnly = true;
            }
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
                MessageBox.Show("You are not whitelisted!");
                Environment.Exit(0);
            }
        }

        private void activateButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Whitelisting your account...";

            bool worked = Whitelisting.Auth.WhitelistUser(keyTextBox.Text.ToString());

            if (worked)
            {
                MessageBox.Show("You have been whitelisted! Reopen the program to continue.");
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Unable to whitelist your account!");
                Environment.Exit(0);
            }
        }
    }
}
