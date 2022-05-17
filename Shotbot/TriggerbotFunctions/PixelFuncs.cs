using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace Shotbot.TriggerbotFunctions
{
    internal class PixelFuncs
    {
        public static Bitmap GetPixelPicture()
        {
            Rectangle rect = new Rectangle(Settings.monitor.Bounds.Width / 2 - (Settings.xPixels / 2), Settings.monitor.Bounds.Height / 2 - (Settings.xPixels / 2), Settings.xPixels, Settings.yPixels);
            var bmp = new BitDat.DirectBitmap(rect.Width, rect.Height);
            var g = Graphics.FromImage(bmp.Bitmap);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size(), CopyPixelOperation.SourceCopy);

            return bmp.Bitmap;
        }

    }
}
