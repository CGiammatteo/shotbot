using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

namespace Shotbot.Keybinds
{
    internal class BindWorker
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private static SpeechSynthesizer synth = new SpeechSynthesizer();

        public static void Worker()
        {
            while (true)
            {
                if ((GetAsyncKeyState(Settings.enableTriggerbotKeybind) & 0x8000) > 0)
                {
                    Settings.enabled = !Settings.enabled;

                    if (Settings.enabled)
                    {
                        synth.Speak("On");
                    }
                    else
                    {
                        synth.Speak("Off");
                    }
                }

                Thread.Sleep(1);
            }
        }
    }
}
