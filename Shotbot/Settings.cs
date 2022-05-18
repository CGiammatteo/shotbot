using System;
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
        public static int shotSpeed = 100; //miliseconds
        public static int shotDelay = 75; //miliseconds
        public static Keys enableTriggerbotKeybind = Keys.None;
        public static int chosenColor = 1;
        public static bool isShooting = false;
        public static DateTime expiration { get; set; }
        public static string version = "1.1";
    }
}
