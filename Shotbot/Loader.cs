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
