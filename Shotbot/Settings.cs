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
        public static DateTime expiration { get; set; }
        public static string version = "1.41";

        public static Color overlayColor = Color.FromArgb(255,255,255,0);

        public static int outlineThreshold = 0;
        public static Color outlineColor = Color.FromArgb(255, 175, 46, 175);

        public static Keys flankKeybind = Keys.None;
        public static bool flankEnabled = false;
    }
}
