using System;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shotbot
{
    public partial class ValMain : MetroFramework.Forms.MetroForm
    {
        private static Random random = new Random();
        private Overlay overlay = new Overlay();

        public ValMain()
        {
            InitializeComponent();
        }

        private void ValMain_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = File.OpenText(@"C:\Program Files\Shotbot\config.json"))
            {
                using (JsonReader jreader = new JsonTextReader(reader))
                {
                    JObject o1 = (JObject)JToken.ReadFrom(jreader);
                    KeysConverter kt = new KeysConverter();
                    Settings.xPixels = Convert.ToInt32(o1["XPixels"]);
                    metroTrackBar1.Value = Settings.xPixels;
                    xPixelsLabel.Text = $"Pixels: {Settings.xPixels}x{Settings.xPixels}";
                    Settings.yPixels = Convert.ToInt32(o1["YPixels"]);
                    Settings.audio = Convert.ToBoolean(o1["Audio"]);
                    audioCheckBox.Checked = Settings.audio;
                    Settings.shotDelay = Convert.ToInt32(o1["ShotDelay"]);
                    metroTextBox1.Text = Convert.ToString(Settings.shotDelay);
                    Settings.shotSpeed = Convert.ToInt32(o1["ShotSpeed"]);
                    delayTextBox.Text = Convert.ToString(Settings.shotSpeed);
                    Settings.chosenColor = Convert.ToInt32(o1["ChosenColor"]);
                    try
                    {
                    Keys key = (Keys)Enum.Parse(typeof(Keys), Convert.ToString(o1["KeyBind"]), true);
                        Settings.enableTriggerbotKeybind = key;
                        triggerbotKeybindButton.Text = $"Keybind: {o1["KeyBind"]}";
                    }
                    catch
                    {
                        Keys key = Keys.Alt;
                        Settings.enableTriggerbotKeybind = key;
                        triggerbotKeybindButton.Text = $"Keybind: Alt";
                    }
                   
                    switch (Settings.chosenColor)
                    {
                        case 1:
                            redRadioButton.Checked = true;
                            break;
                        case 2:
                            purpleRadioButton.Checked = true;
                            break;
                        case 3:
                            yellowRadioButton.Checked = true;
                            break;
                        default:
                            redRadioButton.Checked = true;
                            break;
                    }
                }
            }

            string curFileName = Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName);

            File.Move(AppDomain.CurrentDomain.FriendlyName, RandomString(random.Next(10, 20)) + ".exe");

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen == null)
                    continue;

                monitorComboBox.Items.Add(screen.DeviceName.ToString());
            }

            Thread Trigger = new Thread(TriggerbotFunctions.TriggerbotWorker.trigWorker) { IsBackground = true };
            Thread Binds = new Thread(Keybinds.BindWorker.Worker) { IsBackground = true };
            Thread Time = new Thread(Whitelisting.ExpirationCheck.ExpireWorker) { IsBackground = true };

            Trigger.Start();
            Binds.Start();
            Time.Start();

            expirationLabel.Text = $"License expiration: {Settings.expiration.ToLocalTime().Date}";

            //load config here (config in shotbot folder, json format)
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void ValMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Misc.ConfigSaving.SaveConfig();
        }

        private void ValMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pixelTrackBar_ValueChanged(object sender, EventArgs e)
        {
            xPixelsLabel.Text = "Pixels: " + pixelTrackBar.Value.ToString();
            Settings.xPixels = pixelTrackBar.Value;
            Settings.yPixels = pixelTrackBar.Value;
        }

        private void redRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.chosenColor = 1;
        }

        private void purpleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.chosenColor = 2;
        }

        private void yellowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Settings.chosenColor = 3;
        }

        private void audioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.audio = audioCheckBox.Checked;
        }

        private void topmostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = topmostCheckBox.Checked;
        }

        private void monitorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(Screen sc in Screen.AllScreens)
            {
                if (sc != null && sc.DeviceName == monitorComboBox.SelectedItem.ToString())
                    Settings.monitor = sc;
            }
        }

        private void triggerbotKeybindButton_Click(object sender, EventArgs e)
        {
            string bindName = Keybinds.BindCreator.SetBind();
            if (bindName != "None")
            {
                triggerbotKeybindButton.Text = $"Keybind: {bindName}";
            }
        }

        private void delaySetButton_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(delayTextBox.Text) < 5 || delayTextBox.Text == "")
            {
                MessageBox.Show("Cannot set a value less than 5!", "Error");
            }
            else
            {
                Settings.shotSpeed = Convert.ToInt32(delayTextBox.Text);
                MessageBox.Show($"Set shot speed to {Settings.shotSpeed} successfully!", "Success!");
            }
        }

        private void delayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(delayTextBox.Text) < 50 || delayTextBox.Text == "")
            {
                MessageBox.Show("Cannot set a value less than 50!", "Error");
            }
            else
            {
                Settings.shotDelay = Convert.ToInt32(metroTextBox1.Text);
                MessageBox.Show($"Set shot delay to {Settings.shotDelay} successfully!", "Success!");
            }
        }

        private void metroTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            xPixelsLabel.Text = "Pixels: " + metroTrackBar1.Value + "x" + metroTrackBar1.Value;
            Settings.xPixels = metroTrackBar1.Value;
            Settings.yPixels = metroTrackBar1.Value;
        }

        private void overlayToggle_Click(object sender, EventArgs e)
        {
            Settings.overlayEnabled = !Settings.overlayEnabled;

            if (Settings.overlayEnabled)
            {
                overlay.Show();
                overlayToggle.Text = "Disable overlay";
            }
            else
            {
                overlay.Hide();
                overlayToggle.Text = "Enable overlay";
            }
        }
    }
}
