using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                o1["ChosenColor"] = Settings.chosenColor;
                o1["KeyBind"] = kt.ConvertToString(Settings.enableTriggerbotKeybind);
                o1["OverlayColor"] = Settings.overlayColor.ToString();
                o1["ColorSens"] = Settings.colorMultiplier;

                serializer.Serialize(file, o1);
            }
        }
    }
}
