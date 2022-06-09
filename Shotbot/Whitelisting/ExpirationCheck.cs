using System;
using System.Windows.Forms;

namespace Shotbot.Whitelisting
{
    internal class ExpirationCheck
    {
        public static void ExpireWorker()
        {
            while (true)
            {
                if(Convert.ToDateTime(DateTime.UtcNow) > Settings.expiration)
                {
                    Auth.DeleteLicense(Auth.GrabKey());
                    MessageBox.Show("Your license time has ran out! To use Shotbot again, you must purchase another license!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
