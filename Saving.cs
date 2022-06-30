using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace CoffeeVault2
{
    internal class Saving
    {
        public static  List<Setting> localSettings;
        public static void SaveAvatar(string post, string path, string playerid)
        {
            Avatar json = JsonConvert.DeserializeObject<Avatar>(post);
            Avatar newavatar = new Avatar()
            {
                OutfitSelections = json.OutfitSelections,
                HairColor = json.HairColor,
                SkinColor = json.SkinColor,
                FaceFeatures = json.FaceFeatures
            };
            try
            {
                Console.WriteLine("[Saving] Attempting to save avatar...");
                File.WriteAllText(path + "\\" + playerid + "\\Avatar.json", JsonConvert.SerializeObject(newavatar));
                Console.WriteLine("[Saving] Avatar saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Saving] Avatar failed to save!");
            }
        }
        public static void SaveSettings(string post, string path, string playerid)
        {
            localSettings = JsonConvert.DeserializeObject<List<Setting>>(File.ReadAllText(path + "\\" + playerid + "\\Settings.json"));
            Console.WriteLine("[Saving] Attempting to Save Settings...");
            Setting setting = JsonConvert.DeserializeObject<Setting>(post);
            for (int i = 0; i < localSettings.Count; i++)
            {
                bool keyValid = localSettings[i].Key == setting.Key;
                if (keyValid)
                {
                    localSettings[i].Value = setting.Value;
                    goto Save;

                }
            }
            localSettings.Add(new Setting
            {
                Key = setting.Key,
                Value = setting.Value
            });
        Save:;
            try
            {
                File.WriteAllText(path + "\\" + playerid + "\\Settings.json", JsonConvert.SerializeObject(localSettings));
                Console.WriteLine("[Saving] Settings Save Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Saving] Failed to save Settings. Reason: " + ex.ToString());
            }

        }
    }
    public class Setting
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
