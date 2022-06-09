using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shotbot
{
    internal class Settings
    {
        public static int xPixels = 10;
        public static int yPixels = 10;
        public static Screen monitor = Screen.PrimaryScreen;
        public static bool audio = true;
        public static bool enabled = false;
        public static bool overlayEnabled = false;
        public static int shotSpeed = 100; //miliseconds
        public static int shotDelay = 75; //miliseconds
        public static Keys enableTriggerbotKeybind = Keys.Alt;
        public static int chosenColor = 1;
        public static DateTime expiration { get; set; }
        public static string version = "1.21b";

        public static Color overlayColor = Color.FromArgb(255,255,255,0);

        public static int colorMultiplier = 1;
    }
}
