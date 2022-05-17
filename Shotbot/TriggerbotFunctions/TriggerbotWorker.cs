using System;
using System.Drawing;
using System.Threading;

namespace Shotbot.TriggerbotFunctions
{
    internal class TriggerbotWorker
    {
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

                            if (Settings.chosenColor == 1)
                            {
                                if (ColorFuncs.CompareRed(col) && hasShot == false)
                                {
                                    hasShot = true;
                                    MouseFuncs.ShootGun();
                                    Thread.Sleep(rand);
                                }
                            }

                            if (Settings.chosenColor == 2)
                            {
                                if (ColorFuncs.ComparePurple(col) && hasShot == false)
                                {
                                    hasShot = true;
                                    MouseFuncs.ShootGun();
                                    Thread.Sleep(rand);
                                }
                            }

                            if (Settings.chosenColor == 3)
                            {
                                if (ColorFuncs.CompareYellow(col) && hasShot == false)
                                {
                                    hasShot = true;
                                    MouseFuncs.ShootGun();
                                    Thread.Sleep(rand);
                                }
                            }
                        }
                    }
                }
                hasShot = false;
                Thread.Sleep(1);
            }
        }
    }
}
