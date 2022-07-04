using System;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shotbot.TriggerbotFunctions
{

    internal class TriggerbotWorker
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private static Random r = new Random();
        private static Rectangle rect = new Rectangle(Settings.monitor.Bounds.Width / 2 - (Settings.xPixels / 2), Settings.monitor.Bounds.Height / 2 - (Settings.xPixels / 2), Settings.xPixels, Settings.yPixels);
        private static bool hasShot = false;
        public static void trigWorker()
        {
            while (true)
            {
                if (Settings.enabled)
                {
                    var bmp = new BitDat.DirectBitmap(rect.Width, rect.Height);
                    var g = Graphics.FromImage(bmp.Bitmap);
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size(), CopyPixelOperation.SourceCopy);

                    for (int x = 0; x < rect.Width; x++)
                    {
                        for (int y = 0; y < rect.Height; y++)
                        {
                            Color col = bmp.GetPixel(x, y);
                            int rand = r.Next(Settings.shotSpeed, Settings.shotSpeed + r.Next(1, 10));

                            if (ColorFuncs.CompareOutline(col) && hasShot == false)
                            {
                                hasShot = true;
                                if(Settings.flankEnabled == true && GetAsyncKeyState(Keys.W) > 0 || GetAsyncKeyState(Keys.A) > 0 || GetAsyncKeyState(Keys.S) > 0 || GetAsyncKeyState(Keys.D) > 0)
                                    MouseFuncs.ShootGun();

                                if (Settings.flankEnabled == false)
                                    MouseFuncs.ShootGun();
                                Thread.Sleep(rand);
                            }
                        }
                    }

                    bmp.Dispose();
                    g.Dispose();
                }
                hasShot = false;
                Thread.Sleep(1);
            }
        }
    }
}
