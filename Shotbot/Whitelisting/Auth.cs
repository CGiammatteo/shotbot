using System;
using Npgsql;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Shotbot.Whitelisting
{
    internal class Auth
    {
        private static string cs = "Host=db.bit.io;Username=cgiammatteo112_demo_db_connection;Password=3ni4d_hA8SPKPhyUDqWa3kHjjn7f4;Database=shotbot";
        private static NpgsqlConnection connection = new NpgsqlConnection(cs);

        public static bool AuthenticateUser()
        {
            bool isWhitelisted = false;
            string key = GrabKey();
            string hwid = Hwid.GrabHwid();

            if (key == null)
                return false;

            connection.Open();
            var sql = "SELECT * FROM \"cgiammatteo112/shotbot\".\"data\";";

            var cmd = new NpgsqlCommand(sql, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            while (reader.Read())
            {
                for (int colNum = 0; colNum < reader.FieldCount; colNum++)
                {
                    if (reader.GetName(colNum) == "key")
                    {
                        if (Convert.ToString(reader[colNum]) == Convert.ToString(key))
                        {
                            if (Convert.ToString(reader[colNum + 1]) == hwid)
                            {
                                DateTime dat = Convert.ToDateTime(reader[colNum + 2]);

                                if (dat > DateTime.UtcNow) //date check not working
                                {
                                    Settings.expiration = dat;
                                    isWhitelisted = true;
                                }
                                else
                                {
                                    isWhitelisted = false;
                                }
                            }
                            else
                            {
                                isWhitelisted = false;
                            }
                        }
                    }
                }
            }
            connection.Close();

            return isWhitelisted;
        }

        public static bool WhitelistUser(string key)
        {
            bool success = false;

            connection.Open();

            var sql = "SELECT * FROM \"cgiammatteo112/shotbot\".\"data\";";
            string licenseType = "";

            var cmd = new NpgsqlCommand(sql, connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();

            while (reader.Read())
            {
                for (int colNum = 0; colNum < reader.FieldCount; colNum++)
                {
                    if (reader.GetName(colNum) == "key" && Convert.ToString(reader[colNum]) == key)
                    {
                        if (Convert.ToString(reader[colNum + 1]) == "")
                        {
                            licenseType = Convert.ToString(reader[colNum + 3]);
                            //key is not being used, whitelist user
                            success = true;
                        }
                        else
                        {
                            //key is being used, cannot whitelist
                            success = false;
                        }
                    }
                }
            }
            connection.Close();

            DateTime time = DateTime.UtcNow;

            if (licenseType == "week")
            {
                time = time.AddDays(7);
            }
            else if (licenseType == "month")
            {
                time = time.AddMonths(1);
            }
            else if (licenseType == "3months")
            {
                time = time.AddMonths(3);
            }

            if (success == true)
            {
                connection.Open();

                var sqlCmd = $"UPDATE \"cgiammatteo112/shotbot\".\"data\" SET hwid='{Hwid.GrabHwid()}', time='{time}' WHERE key='{key}';";
                var cmdSent = new NpgsqlCommand(sqlCmd, connection);
                cmdSent.ExecuteNonQuery();

                connection.Close();


                SetKey(key);
                //set key in config.json file

            }

            return success;
        }

        public static string GrabKey()
        {
            if (!Directory.Exists(@"C:\Program Files\Shotbot\"))
            {
                Directory.CreateDirectory(@"C:\Program Files\Shotbot\");
                using (StreamWriter file = File.CreateText(@"C:\Program Files\Shotbot\config.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    JObject configData = new JObject(
                        new JProperty("Key", ""),
                        new JProperty("XPixels", Settings.xPixels),
                        new JProperty("YPixels", Settings.yPixels),
                        new JProperty("Audio", Settings.audio),
                        new JProperty("ShotDelay", Settings.shotDelay),
                        new JProperty("ShotSpeed", Settings.shotSpeed),
                        new JProperty("ChosenColor", Settings.chosenColor));

                    serializer.Serialize(file, configData);
                }
                return "";
            }
            else
            {
                using (StreamReader reader = File.OpenText(@"C:\Program Files\Shotbot\config.json"))
                {
                    using (JsonReader jreader = new JsonTextReader(reader))
                    {
                        JObject o2 = (JObject)JToken.ReadFrom(jreader);

                        return o2["Key"].ToString();
                    }
                }
            }
        }

        public static void SetKey(string key)
        {
            JObject o1 = new JObject();
            using (StreamReader reader = File.OpenText(@"C:\Program Files\Shotbot\config.json"))
            {
                using (JsonReader jreader = new JsonTextReader(reader))
                {
                    o1 = (JObject)JToken.ReadFrom(jreader);

                    o1["Key"] = key;
                }
            }

            using (StreamWriter file = File.CreateText(@"C:\Program Files\Shotbot\config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;

                serializer.Serialize(file, o1);
            }
        }

        public static void DeleteLicense(string key)
        {
            JObject o1 = new JObject();
            using (StreamReader reader = File.OpenText(@"C:\Program Files\Shotbot\config.json"))
            {
                using (JsonReader jreader = new JsonTextReader(reader))
                {
                    o1 = (JObject)JToken.ReadFrom(jreader);

                    o1["Key"] = "";
                }
            }

            using (StreamWriter file = File.CreateText(@"C:\Program Files\Shotbot\config.json"))
            {
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;

                    serializer.Serialize(file, o1);
                }

                connection.Open();

                var sqlCmd = $"DELETE FROM \"cgiammatteo112/shotbot\".\"data\" WHERE key='{key}';";
                var cmdSent = new NpgsqlCommand(sqlCmd, connection);
                cmdSent.ExecuteNonQuery();

                connection.Close();
            }

        }
    }
}
