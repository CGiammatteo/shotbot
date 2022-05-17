using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shotbot.Keybinds
{
    internal class BindCreator
    {

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public static string SetBind()
        {
            bool found = false;
            Keys foundKey = Keys.None;
            string keyName = "";
            string final = "None";

            while (found == false)
            {
                foreach (int i in Enum.GetValues(typeof(Keys)))
                {
                    if (GetAsyncKeyState(i) == -32767)
                    {
                        keyName = Enum.GetName(typeof(Keys), i);
                        foundKey = (Keys)Enum.Parse(typeof(Keys), keyName, true);
                        found = true;

                        DialogResult dResult = MessageBox.Show($"Are you sure you would like to set the triggerbot's keybind to {foundKey}?", "Keybind", MessageBoxButtons.YesNo);

                        if (dResult == DialogResult.Yes)
                        {
                            if (foundKey == Settings.enableTriggerbotKeybind)
                            {
                                MessageBox.Show("Unable to set keybind! (Error: key already set to another bind)");
                            }
                            else
                            {
                                final = keyName;

                                Settings.enableTriggerbotKeybind = foundKey;
                            }
                        }
                    }
                }
            }
            return final;
        }

    }
}
