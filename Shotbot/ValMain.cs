using System;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.ComponentModel;

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
            

            this.Text = RandomString(random.Next(10, 20));
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

                    Settings.outlineThreshold = Convert.ToInt32(o1["OutlineThreshold"]);
                    thresholdBox.Text = Convert.ToString(Settings.outlineThreshold);

                    try
                    {
                        int[] overlayInts = Misc.ColorStuff.ConvertColor(o1["OverlayColor"].ToString());
                        Settings.overlayColor = Color.FromArgb(overlayInts[0], overlayInts[1], overlayInts[2], overlayInts[3]);
                        overlayColorButton.BackColor = Settings.overlayColor;
                    }
                    catch
                    {
                        Settings.overlayColor = Color.FromArgb(255, 255, 255, 255);
                        overlayColorButton.BackColor = Settings.overlayColor;
                    }

                    try
                    {
                        int[] outlineInts = Misc.ColorStuff.ConvertColor(o1["OutlineColor"].ToString());
                        Settings.outlineColor = Color.FromArgb(outlineInts[0], outlineInts[1], outlineInts[2], outlineInts[3]);
                        colorPreview.BackColor = Settings.outlineColor;
                    }
                    catch
                    {
                        Settings.outlineColor = Color.FromArgb(255, 175, 46, 175);
                        colorPreview.BackColor = Settings.outlineColor;
                    }

                    try
                    {
                    Keys key = (Keys)Enum.Parse(typeof(Keys), Convert.ToString(o1["KeyBind"]), true);
                        Settings.enableTriggerbotKeybind = key;
                        triggerbotKeybindButton.Text = $"Keybind: {o1["KeyBind"]}";

                    Keys key2 = (Keys)Enum.Parse(typeof(Keys), Convert.ToString(o1["FlankBind"]), true);
                        Settings.flankKeybind = key;
                        flankBindButton.Text = $"Keybind: {o1["FlankBind"]}";
                    }
                    catch
                    {
                        Keys key = Keys.None;
                        Settings.enableTriggerbotKeybind = key;
                        triggerbotKeybindButton.Text = $"Keybind: None";

                        Settings.flankKeybind = key;
                        flankBindButton.Text = $"Keybind: None";
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

            var IsLinked = Whitelisting.Auth.IsLinked(Whitelisting.Auth.GrabKey());
            if (IsLinked)
            {
                DiscordLinkAlert.Visible = false;  
            }
            else
            {
                DiscordLinkAlert.Visible = true;
            }
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
            string bindName = Keybinds.BindCreator.SetBind(0);
            if (bindName != "None")
            {
                triggerbotKeybindButton.Text = $"Keybind: {bindName}";
            }
        }

        private void delaySetButton_Click(object sender, EventArgs e)
        {
            Settings.shotSpeed = Convert.ToInt32(delayTextBox.Text);
            MessageBox.Show($"Set shot speed to {Settings.shotSpeed} successfully!", "Success!");
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
            Settings.shotDelay = Convert.ToInt32(metroTextBox1.Text);
            MessageBox.Show($"Set shot delay to {Settings.shotDelay} successfully!", "Success!");
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

        private void overlayColorButton_Click(object sender, EventArgs e)
        {
            if (overlayColorDialogue.ShowDialog() == DialogResult.OK)
            {
                Settings.overlayColor = Color.FromArgb(overlayColorDialogue.Color.A, overlayColorDialogue.Color.R, overlayColorDialogue.Color.G, overlayColorDialogue.Color.B);
                overlayColorButton.BackColor = overlayColorDialogue.Color;
            }
        }

        private void thresholdBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void setColorSettings_Click(object sender, EventArgs e)
        {
            Settings.outlineThreshold = Convert.ToInt32(thresholdBox.Text.ToString());
            Settings.outlineColor = colorPreview.BackColor;

            MessageBox.Show("Set settings successfully!");
        }

        private void saveColor_Click(object sender, EventArgs e)
        {
            //from json file
            bool tried = Misc.ConfigSaving.SaveColorConfig();

            if (tried)
            {
                MessageBox.Show("Created config successfully!");
            }
            else
            {
                MessageBox.Show("Unable to create config!");
            }
        }

        private void loadColor_Click(object sender, EventArgs e)
        {
            //from json file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = AppContext.BaseDirectory + @"\Configs\";
            openFileDialog1.Filter = "Json files (*.json)|*.json";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                bool tried = Misc.ConfigSaving.LoadColorConfig(selectedFileName);

                if (!tried)
                {
                    MessageBox.Show("Unable to load config!");
                }
                else
                {
                    thresholdBox.Text = Convert.ToString(Settings.outlineThreshold);
                    colorPreview.BackColor = Settings.outlineColor;
                }
            }

        }

        private void chooseOutlineColor_Click(object sender, EventArgs e)
        {
            if (overlayColorDialogue.ShowDialog() == DialogResult.OK)
            {
                Settings.outlineColor = Color.FromArgb(overlayColorDialogue.Color.A, overlayColorDialogue.Color.R, overlayColorDialogue.Color.G, overlayColorDialogue.Color.B);
                colorPreview.BackColor = overlayColorDialogue.Color;
            }
        }

        private void flankBindButton_Click(object sender, EventArgs e)
        {
            string bindName = Keybinds.BindCreator.SetBind(1);
            if (bindName != "None")
            {
                flankBindButton.Text = $"Keybind: {bindName}";
            }
        }
    }
}
