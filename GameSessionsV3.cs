using System;
using System.Collections.Generic;
using System.Text;
using CoffeeVault2;
using Newtonsoft.Json;

namespace RecNootServer
{
    public class GameSessionsV3
    {
        public static Responce responce;
        public static string joinRoom(string post)
        {
            GamePost json = JsonConvert.DeserializeObject<GamePost>(post);
            Console.WriteLine("[GameSessionsV3] Attempting to find room " + json.RoomName);
            if (RROS.ContainsKey(json.RoomName))
            {
                Console.WriteLine("[GameSesionsV3] Room Found! Attempting to join...");
                responce = new Responce()
                {
                    Result = 0,
                    GameSession = new GameSessionData()
                    {
                        GameSessionId = 1987,
                        PhotonRegionId = "us",
                        PhotonRoomId = "RecNoot" + json.RoomName,
                        Name = json.RoomName,
                        RoomId = RROS[json.RoomName].Room.RoomId,
                        RoomSceneId = RROS[json.RoomName].Scenes[0].RoomSceneId,
                        RoomSceneLocationId = RROS[json.RoomName].Scenes[0].RoomSceneLocationId,
                        IsSandbox = RROS[json.RoomName].Scenes[0].IsSandbox,
                        DataBlobName = RROS[json.RoomName].Scenes[0].DataBlobName,
                        PlayerEventId = null,
                        Private = json.Private,
                        GameInProgress = false,
                        MaxCapacity = RROS[json.RoomName].Scenes[0].MaxPlayers,
                        IsFull = false
                    },
                    RoomDetails = RROS[json.RoomName]
                };
                
            }
            else
            {
                Console.WriteLine("[GameSessionsV3] Unable to find room " + json.RoomName + "! Joining DormRoom Instead!");
                responce = new Responce()
                {
                    Result = 0,
                    GameSession = new GameSessionData()
                    {
                        GameSessionId = 1987,
                        PhotonRegionId = "us",
                        PhotonRoomId = "RecNootDormRoom",
                        Name = "DormRoom",
                        RoomId = RROS["DormRoom"].Room.RoomId,
                        RoomSceneId = RROS["DormRoom"].Scenes[0].RoomSceneId,
                        RoomSceneLocationId = RROS["DormRoom"].Scenes[0].RoomSceneLocationId,
                        IsSandbox = RROS["DormRoom"].Scenes[0].IsSandbox,
                        DataBlobName = RROS["DormRoom"].Scenes[0].DataBlobName,
                        PlayerEventId = null,
                        Private = json.Private,
                        GameInProgress = false,
                        MaxCapacity = RROS["DormRoom"].Scenes[0].MaxPlayers,
                        IsFull = false
                    },
                    RoomDetails = RROS["DormRoom"]
                };

                
            }
            Console.WriteLine(JsonConvert.SerializeObject(responce));
            return JsonConvert.SerializeObject(responce);


        }
        public static Presence PresenceV3()
        {
            if (responce == null)
            {
                responce = new Responce()
                {
                    Result = 0,
                    GameSession = new GameSessionData()
                    {
                        GameSessionId = 1987,
                        PhotonRegionId = "us",
                        PhotonRoomId = "RecNootDormRoom",
                        Name = "DormRoom",
                        RoomId = RROS["DormRoom"].Scenes[0].RoomId,
                        RoomSceneId = RROS["DormRoom"].Scenes[0].RoomSceneId,
                        RoomSceneLocationId = RROS["DormRoom"].Scenes[0].RoomSceneLocationId,
                        IsSandbox = RROS["DormRoom"].Scenes[0].IsSandbox,
                        DataBlobName = RROS["DormRoom"].Scenes[0].DataBlobName,
                        PlayerEventId = null,
                        Private = false,
                        GameInProgress = false,
                        MaxCapacity = RROS["DormRoom"].Scenes[0].MaxPlayers,
                        IsFull = false
                    },
                    RoomDetails = RROS["DormRoom"]
                };
            }

            Presence presence = new Presence()
            {
                PlayerId = Program.player.Id,
                IsOnline = true,
                PlayerType = 2,
                GameSession = responce
            };
            return presence;
                
        }
        public static Dictionary<string, RoomRoot> RROS = new Dictionary<string, RoomRoot>
        {
            {
                "DormRoom",
                new RoomRoot()
                {
                    Room = new Room()
                    {
                        RoomId = 1,
                        Name = "DormRoom",
                        Description = "Your own private room to prepare for a big day in Rec Room!",
                        CreatorPlayerId = 1,
                        ImageName = "DormRoom.png",
                        State = 0,
                        Accessibility = 1,
                        SupportsLevelVoting = false,
                        IsAGRoom = true,
                        CloningAllowed = false,
                        SupportsScreens = true,
                        SupportsTeleportVR = true,
                        SupportsWalkVR = true
                    },
                    Scenes = new List<Scene>()
                    {
                        new Scene()
                        {
                            RoomSceneId = 1,
                            RoomId = 1,
                            RoomSceneLocationId = "76d98498-60a1-430c-ab76-b54a29b7a163",
                            Name = "dormroom2",
                            IsSandbox = false,
                            DataBlobName = String.Empty,
                            MaxPlayers = 20,
                            CanMatchmakeInto = true,
                            DataModifiedAt = DateTime.Now
                        }
                        
                    },
                    CoOwners = new List<int>(),
                    InvitedCoOwners = new List<int>(),
                    Hosts = new List<int>(),
                    InvitedHosts = new List<int>(),
                    CheerCount = 0,
                    FavoriteCount = 0,
                    VisitCount = 0,
                    Tags = new List<Tags>()
                    {
                        new Tags()
                        {
                            Tag = "DormRoom",
                            Type = 2
                        }
                       
                    }
                }
            }
        };
    }
    public class Presence
    {
        public ulong PlayerId { get; set; }
        public bool IsOnline { get; set; }
        public int PlayerType { get; set; }
        public Responce GameSession { get; set; }
    }
    public class Responce
    {
        public int Result { get; set; }
        public GameSessionData GameSession { get; set; }
        public RoomRoot RoomDetails { get; set; }
    }
    public class GamePost
    {
        public ulong[] ExpectedPlayerIds { get; set; }
        public List<RegionPings> RegionPings { get; set; }
        public string[] RoomTags { get; set; }
        public string RoomName { get; set; }
        public string SceneName { get; set; }
        public int AdditionalPlayerJoinMode { get; set; }
        public bool Private { get; set; }
    }
    public class RegionPings
    {
        public string Region { get; set; }
        public int Ping { get; set; }
    }
    public class GameSessionData
    {
        public int GameSessionId { get; set; }
        public string PhotonRegionId { get; set; }
        public string PhotonRoomId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public int RoomSceneId { get; set; }
        public string RoomSceneLocationId { get; set; }
        public bool IsSandbox { get; set; }
        public string DataBlobName { get; set; }
        public int? PlayerEventId { get; set; }
        public bool Private { get; set; }
        public bool GameInProgress { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsFull { get; set; }
    }
    public class RoomRoot
    {
        public Room Room { get; set; }
        public List<Scene> Scenes { get; set; }
        public List<int> CoOwners { get; set; }
        public List<int> InvitedCoOwners { get; set; }
        public List<int> Hosts { get; set; }
        public List<int> InvitedHosts { get; set; }
        public int CheerCount { get; set; }
        public int FavoriteCount { get; set; }
        public int VisitCount { get; set; }
        public List<Tags> Tags { get; set; }
    }
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorPlayerId { get; set; }
        public string ImageName { get; set; }
        public int State { get; set; }
        public int Accessibility { get; set; }
        public bool SupportsLevelVoting { get; set; }
        public bool IsAGRoom { get; set; }
        public bool CloningAllowed { get; set; }
        public bool SupportsScreens { get; set; }
        public bool SupportsTeleportVR { get; set; }
        public bool SupportsWalkVR { get; set; }
    }
    public class Scene
    {
        public int RoomSceneId { get; set; }
        public int RoomId { get; set; }
        public string RoomSceneLocationId { get; set; }
        public string Name { get; set; }
        public bool IsSandbox { get; set; }
        public string DataBlobName { get; set; }
        public int MaxPlayers { get; set; }
        public bool CanMatchmakeInto { get; set; }
        public DateTime DataModifiedAt { get; set; }
       
    }
    public class Tags
    {
        public string Tag { get; set; }
        public int Type { get; set; }
    }

}
