using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Shotbot
{
    public partial class Overlay : Form
    {
        private static Random random = new Random();
        private static Font drawingFont = new Font("Arial", 16, FontStyle.Bold);

        [DllImport("User32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("User32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            this.Text = RandomString(random.Next(10, 20));
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.WindowState = FormWindowState.Maximized;
            this.TransparencyKey = this.BackColor;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Top = Screen.PrimaryScreen.Bounds.Top;
            this.Left = Screen.PrimaryScreen.Bounds.Left;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            Timer Update = new Timer();
            Update.Interval = 1;
            Update.Tick += new EventHandler(Update_Tick);
            Update.Start();
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Refresh();
            }
            catch { }
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case 0x000F: // WM_PAINT
                    this.Refresh();
                    break;
            }
            base.WndProc(ref m);
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Settings.overlayColor);
            Pen pen = new Pen(brush);

            e.Graphics.DrawString($"Shotbot [V{Settings.version}]", drawingFont, brush, Screen.PrimaryScreen.Bounds.X + 50, Screen.PrimaryScreen.Bounds.Y + 50);
            e.Graphics.DrawRectangle(pen, 45, 47, 220, 30);

            Rectangle rectMid = new Rectangle(Settings.monitor.Bounds.Width / 2 - (Settings.xPixels / 2), Settings.monitor.Bounds.Height / 2 - (Settings.xPixels / 2), Settings.xPixels, Settings.yPixels);
            e.Graphics.DrawRectangle(pen, rectMid);

            brush.Dispose();
            pen.Dispose();
        }
    }
}
