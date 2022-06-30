using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace CoffeeVault2
{
    public class PlatformLoginLogic
    {
        public static string loginCached()
        {
            return JsonConvert.SerializeObject(new Login
            {
                Error = "",
                Player = JsonConvert.DeserializeObject<Player>(File.ReadAllText(Program.fullpath + "\\Player.json")),
                Token = Program.player.Id.ToString(),
                AnalyticsSessionId = 6942069,
                CanUseScreenMode = true,
                FirstLoginOfTheDay = false
            });
        }
    }
    public class Player
    {
        public ulong Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public int XP { get; set; }
        public int Level { get; set; }
        public int RegistrationStatus { get; set; }
        public bool Developer { get; set; }
        public bool CanReceiveInvites { get; set; }
        public string ProfileImageName { get; set; }
        public bool JuniorProfile { get; set; }
        public bool ForceJuniorImages { get; set; }
        public bool PendingJunior { get; set; }
        public bool HasBirthday { get; set; }
        public bool AvoidJuniors { get; set; }
        public Reputation PlayerReputation { get; set; }
        public List<PlatformIds> PlatformIds { get; set; }
    }
    public class Reputation
    {
        public int Noteriety { get; set; }
        public int CheerGeneral { get; set; }
        public int CheerHelpful { get; set; }
        public int CheerGreatHost { get; set; }
        public int CheerSportsman { get; set; }
        public int CheerCreative { get; set; }
        public int CheerCredit { get; set; }
        public int SubscriberCount { get; set; }
        public int SubscribedCount { get; set; }
        public int SelectedCheer { get; set; }
    }
    public class PlatformIds
    {
        public long Platform { get; set; }
        public long PlatformId { get; set; }
    }
    public class Login
    {
        public string Error { get; set; }
        public Player Player { get; set; }
        public string Token { get; set; }
        public bool FirstLoginOfTheDay { get; set; }
        public ulong AnalyticsSessionId { get; set; }
        public bool CanUseScreenMode { get; set; }
    }
    public class chachedLoginPostData
    {
        public string AppVersion { get; set; }
        public int Platform { get; set; }
        public string PlatformId { get; set; }
        
        public string DeviceId { get; set; }
        public string LoginLockToken { get; set; }
        public string AuthParams { get; set; }
        public string Verify { get; set; }
        public int PlayerId { get; set; }
    }
    public class CreateLoginPostData
    {
        public string AppVersion { get; set; }
        public int Platform { get; set; }
        public string PlatformId { get; set; }
        
        public string DeviceId { get; set; }
        public string LoginLockToken { get; set; }
        public string AuthParams { get; set; }
        public string Verify { get; set; }
        
        public string Email { get; set; }

    }
}
