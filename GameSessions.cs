using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CoffeeVault2.Servers.API;
using Newtonsoft.Json;

namespace CoffeeVault2
{
    internal class GameSessions
    {
        public static GameSession session;
        public static string V2JoinRandom(string post)
        {
            JoinRandom json = JsonConvert.DeserializeObject<JoinRandom>(post);
            session = new GameSession()
            {
               GameSessionId = 1987,
               RegionId = "us",
               RoomId = json.ActivityLevelIds[0],
               RecRoomId = null,
               EventId = null,
               CreatorPlayerId = 0,
               Name = "CoffeeVaut August Room",
               ActivityLevelId = json.ActivityLevelIds[0],
               Private = false,
               Sandbox = false,
               SupportsScreens = true,
               SupportsVR = true,
               MaxCapacity = 69,
               IsFull = false
            };
            JoinResult result = new JoinResult()
            {
                Result = 0,
                GameSession = session
            };
            return JsonConvert.SerializeObject(result);
        }
        public static Presence Presence()
        {
            return new Presence()
            {
                PlayerId = (int)APIMid2018.PID,
                IsOnline = true,
                InScreenMode = false,
                GameSession = session
            };
        }
    }
    public class Presence
    {
        public int? PlayerId { get; set; }
        public bool IsOnline { get; set; }
        public bool InScreenMode { get; set; }
        public GameSession GameSession { get; set; }
    }
    public class GameSession
    {
        public int GameSessionId { get; set; }
        public string RegionId { get; set; }
        public string RoomId { get; set; }
        public int? EventId { get; set; }
        public int? RecRoomId { get; set; }
        public int? CreatorPlayerId { get; set; }
        public string Name { get; set; }
        public string ActivityLevelId { get; set; }
        public bool Private { get; set; }
        public bool Sandbox { get; set; }
        public bool SupportsVR { get; set; }
        public bool SupportsScreens { get; set; }
        public bool GameInProgress { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsFull { get; set; }

    }
    public class RegionPing
    {
        public string Region { get; set; }
        public int Ping { get; set; }
    }
    public class JoinRandom
    {
        public string[] ActivityLevelIds { get; set; }
        public int[] ExpectedPlayerIds { get; set; }
        public RegionPing[] RegionPings { get; set; }
    }
    public class JoinResult
    {
        public int Result { get; set; }
        public GameSession GameSession { get; set; }
    }

}
