using System.Linq;
using System.Management;

namespace Shotbot.Whitelisting
{
    internal class Hwid
    {
        public static string GrabHwid()
        {
            string foundHwid = "";

            ManagementObjectCollection processorList = null;
            ManagementObjectSearcher processor = new ManagementObjectSearcher("Select * From Win32_processor");
            processorList = processor.Get();
            foreach (ManagementObject process in processorList)
            {
                foundHwid += process["ProcessorID"].ToString();
                foundHwid += process["Manufacturer"].ToString();
                foundHwid += process["MaxClockSpeed"].ToString();
            }

            ManagementObjectCollection diskList = null;
            ManagementObjectSearcher disk = new ManagementObjectSearcher("Select * From Win32_DiskDrive");
            diskList = disk.Get();
            foreach (ManagementObject diskFound in diskList)
            {
                foundHwid += diskFound["Model"].ToString();
                foundHwid += diskFound["TotalHeads"].ToString();
            }

            ManagementObjectCollection vidList = null;
            ManagementObjectSearcher vid = new ManagementObjectSearcher("Select * From Win32_VideoController");
            vidList = vid.Get();
            foreach (ManagementObject vvs in vidList)
            {
                foundHwid += vvs["Name"].ToString();
            }

            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            dsk.Get();
            foundHwid += dsk["VolumeSerialNumber"].ToString();

            foundHwid = string.Concat(foundHwid.Where(c => !char.IsWhiteSpace(c)));
            return foundHwid;
        }

        public static bool VerifyHwid(string databaseHwidHash)
        {
            bool isValid = false;

            if(databaseHwidHash == GrabHwid())
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
