using System.Drawing;

namespace Shotbot.TriggerbotFunctions
{
    internal class ColorFuncs
    {
        public static bool CompareRed(Color foundColor)
        {
            int threshold = 30;
            Color red = Color.FromArgb(255,180,21,21);

            int r = (int)red.R - foundColor.R,
                g = (int)red.G - foundColor.G,
                b = (int)red.B - foundColor.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        public static bool ComparePurple(Color foundColor)
        {
            int threshold = 50;
            Color purple = Color.FromArgb(255, 175, 46, 175);

            int r = (int)purple.R - foundColor.R,
                g = (int)purple.G - foundColor.G,
                b = (int)purple.B - foundColor.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        public static bool CompareYellow(Color foundColor)
        {
            int threshold = 35;
            Color yellow = Color.FromArgb(255, 165, 165, 40);

            int r = (int)yellow.R - foundColor.R,
                g = (int)yellow.G - foundColor.G,
                b = (int)yellow.B - foundColor.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        public static bool CompareOutline(Color foundColor)
        {
            int threshold = Settings.outlineThreshold;
            Color col = Settings.outlineColor;

            int r = (int)col.R - foundColor.R,
                g = (int)col.G - foundColor.G,
                b = (int)col.B - foundColor.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }
    }
}
