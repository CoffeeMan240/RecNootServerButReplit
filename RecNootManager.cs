using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CoffeeVault2;
using Newtonsoft.Json;

namespace RecNootServer
{
    public class RecNootManager
    {
        public static string GetPlatformLoginsByPlatformID(string post, string PlatLogin)
        {
            string platformid = post.Remove(0, 22);
            try
            {
               List<Player> player = new List<Player>();
                string[] Players = Directory.GetDirectories(PlatLogin);
                foreach (string pidplayers in Players)
                {
                    if (pidplayers.Contains(platformid))
                    {
                        string[] Pidplayers = Directory.GetFiles(pidplayers);
                        foreach (string pidplayer in Pidplayers)
                        {
                            player.Add(JsonConvert.DeserializeObject<Player>(File.ReadAllText(pidplayer)));
                        }
                    }
                }
                return JsonConvert.SerializeObject(player);
            }
            catch
            {
                return "[]";
            }
            
        }
        public static string CreateAccount(string post, string PlatformLoginPath, string PIDPath, string SharePath)
        { 
            CreateLoginPostData json = JsonConvert.DeserializeObject<CreateLoginPostData>(post);
            //create platform folder
            Directory.CreateDirectory(PlatformLoginPath + "\\" + json.PlatformId);
            Player player = new Player()
            {
                Id = (ulong)new Random().Next(100000000, 999999999),
                Username = RandomUsername(),
                DisplayName = "",
                Bio = "",
                XP = 0,
                Level = 0,
                RegistrationStatus = 2,
                Developer = true,
                CanReceiveInvites = false,
                ProfileImageName = "DefaultProfileImage",
                JuniorProfile = false,
                ForceJuniorImages = false,
                PendingJunior = false,
                HasBirthday = true,
                AvoidJuniors = true,
                PlayerReputation = new Reputation()
                {
                    Noteriety = 0,
                    CheerCreative = 0,
                    CheerCredit = 0,
                    CheerGeneral = 0,
                    CheerGreatHost = 0,
                    CheerHelpful = 0,
                    CheerSportsman = 0,
                    SelectedCheer = 0,
                    SubscribedCount = 0,
                    SubscriberCount = 0,
                },
                PlatformIds = new List<PlatformIds>()
                {
                    new PlatformIds()
                    {
                        Platform = long.Parse(json.PlatformId),
                        PlatformId = long.Parse(json.PlatformId)
                    }
                }

            };
            player.DisplayName = player.Username;
            File.WriteAllText(PlatformLoginPath + "\\" + json.PlatformId + "\\" + player.Id + ".rnoot", JsonConvert.SerializeObject(player));
            Directory.CreateDirectory(PIDPath + "\\" + player.Id);
            File.WriteAllText(PIDPath + "\\" + player.Id + "\\Player.rnoot", JsonConvert.SerializeObject(player));
            File.Copy(SharePath + "\\Settings.json", PIDPath + "\\" + player.Id + "\\Settings.json");
            File.Copy(SharePath + "\\Avatar.json", PIDPath + "\\" + player.Id + "\\Avatar.json");
            Login create = new Login()
            {
                Error = "",
                Player = player,
                Token = player.Id.ToString(),
                AnalyticsSessionId = 6969420,
                CanUseScreenMode = true,
                FirstLoginOfTheDay = false
            };
            return JsonConvert.SerializeObject(create);
        }
        public static string newloginCached(string post, string PIDPath)
        {
            chachedLoginPostData json = JsonConvert.DeserializeObject<chachedLoginPostData>(post);
            return JsonConvert.SerializeObject(new Login()
            {
                Error = "",
                Player = JsonConvert.DeserializeObject<Player>(File.ReadAllText(PIDPath + "\\" + json.PlayerId + "\\Player.rnoot")),
                Token = json.PlayerId.ToString(),
                AnalyticsSessionId = 6969420,
                CanUseScreenMode = true,
                FirstLoginOfTheDay = false
            });
        }
        public static string GetPlayerAvatar(string playerid, string PID)
        {
            return File.ReadAllText(PID + "\\" + playerid + "\\Avatar.json");
        }
        public static string GetSettings(string playerid, string PID)
        {
            return File.ReadAllText(PID + "\\" + playerid + "\\Settings.json");
        }
        public static string RandomUsername()
        {
            string[] Ajt = new string[]
            {
                "Crazy",
                "Sick",
                "Gay",
                "Sus",
                "Cool",
                "Trippy",
                "Stinky",
                "Best-Selling",
                "Sponcered"
            };
            string[] nown = new string[]
            {
                "Nooter",
                "Amogus",
                "Monke",
                "RecRoomian",
                "RecBoomer",
                "Animal",
                "Book",
                "Skunk",
                "Youtuber"
            };
            return string.Format("{0}{1}{2}",Ajt[new Random().Next(0, Ajt.Length)], nown[new Random().Next(0, Ajt.Length)], new Random().Next(1, 9999).ToString());
        }
        public static string SetUsername(string post, string path, string playerid, string plidpath)
        {
            Player player = JsonConvert.DeserializeObject<Player>(File.ReadAllText(path + "\\" + playerid + "\\Player.rnoot"));
            string name = post.Remove(0, 5);
            player.Username = name;
            player.DisplayName = name;
            File.WriteAllText(path + "\\" + playerid + "\\Player.rnoot", JsonConvert.SerializeObject(player));
            string[] plid = Directory.GetDirectories(plidpath);
            foreach (string id in plid)
            {
                string[] pid = Directory.GetFiles(id);
                foreach (string plpid in pid)
                {
                    if (plpid.Contains(player.Id.ToString()))
                    {
                        File.WriteAllText(plpid, JsonConvert.SerializeObject(player));
                    }
                }
            }
            return "{\"Success\": true,\"Message\":\"\"}";
        }
        public static string SetBio(string post, string path, string playerid, string plidpath)
        {
            Player player = JsonConvert.DeserializeObject<Player>(File.ReadAllText(path + "\\" + playerid + "\\Player.rnoot"));

            string name = post.Remove(0, 4);
            player.Bio = name;
            string[] plid = Directory.GetDirectories(plidpath);
            foreach (string id in plid)
            {
                string[] pid = Directory.GetFiles(id);
                foreach (string plpid in pid)
                {
                    if (plpid.Contains(player.Id.ToString()))
                    {
                        File.WriteAllText(plpid, JsonConvert.SerializeObject(player));
                    }
                }
            }
            return "{\"Success\":true,\"Message\":\"\"}";
        }
        public static string ListPlayers(string post, string path)
        {
            List<int> json = JsonConvert.DeserializeObject<List<int>>(post);
            List<Player> players = new List<Player>();
            foreach(int pid in json)
            {
              string[] pids = Directory.GetDirectories(path);
                foreach(string pidpath in pids)
                {
                    if (pidpath.Contains(pid.ToString()))
                    {
                        players.Add(JsonConvert.DeserializeObject<Player>(File.ReadAllText(pidpath + "\\" + pid + "\\Player.rnoot")));
                    }
                }
            }
            return JsonConvert.SerializeObject(players);
        }
    }
}
