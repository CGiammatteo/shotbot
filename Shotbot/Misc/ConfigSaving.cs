using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Shotbot.Misc
{
    internal class ConfigSaving
    {
        public static void SaveConfig()
        {
            KeysConverter kt = new KeysConverter();
            JObject o1 = new JObject();
            using (StreamReader reader = File.OpenText(@"C:\Program Files\Shotbot\config.json"))
            {
                using (JsonReader jreader = new JsonTextReader(reader))
                {
                    o1 = (JObject)JToken.ReadFrom(jreader);
                }
            }

            using (StreamWriter file = File.CreateText(@"C:\Program Files\Shotbot\config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;

                o1["XPixels"] = Settings.xPixels;
                o1["YPixels"] = Settings.yPixels;
                o1["Audio"] = Settings.audio;
                o1["ShotDelay"] = Settings.shotDelay;
                o1["ShotSpeed"] = Settings.shotSpeed;
                o1["KeyBind"] = kt.ConvertToString(Settings.enableTriggerbotKeybind);
                o1["FlankBind"] = kt.ConvertToString(Settings.flankKeybind);
                o1["OverlayColor"] = Settings.overlayColor.ToString();

                o1["OutlineThreshold"] = Settings.outlineThreshold;
                o1["OutlineColor"] = Settings.outlineColor.ToString();

                serializer.Serialize(file, o1);
            }
        }

        public static bool SaveColorConfig()
        {
            JObject o1 = new JObject();

            if (!Directory.Exists(AppContext.BaseDirectory + @"\Configs"))
            {
                Directory.CreateDirectory(AppContext.BaseDirectory + @"\Configs");
            }

            try
            {
                using (StreamWriter file = File.CreateText(AppContext.BaseDirectory + @"\Configs\NewConfig.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;

                    o1["OutlineColor"] = Settings.outlineColor.ToString();
                    o1["Threashold"] = Settings.outlineThreshold;

                    serializer.Serialize(file, o1);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadColorConfig(string fileName)
        {
            JObject o1 = new JObject();

            try
            {
                using (StreamReader reader = File.OpenText(fileName))//issue here
                {
                    using (JsonReader jreader = new JsonTextReader(reader))
                    {
                        o1 = (JObject)JToken.ReadFrom(jreader);
                    }
                }

                int[] outlineInts = Misc.ColorStuff.ConvertColor(Convert.ToString(o1["OutlineColor"]));
                Settings.outlineColor = Color.FromArgb(outlineInts[0], outlineInts[1], outlineInts[2], outlineInts[3]);
                Settings.outlineThreshold  = Convert.ToInt32(o1["Threashold"]);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
