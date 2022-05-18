using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Shotbot.TriggerbotFunctions
{
    internal class MouseFuncs
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        private static Random rnd = new Random();

        public static void LeftDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
        }

        public static void LeftUp()
        {
           mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
        }

        public static void ShootGun()
        {
            Thread.Sleep(rnd.Next(Settings.shotDelay, Settings.shotDelay + 21));
            LeftDown();
            Thread.Sleep(rnd.Next(1, 5));
            LeftUp();
        }
    }
}
