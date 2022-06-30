using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace CoffeeVault2
{
    internal class Config
    {
        public static string GetConfig()
        {
            ConfigClass result = new ConfigClass()
            {
                MessageOfTheDay = "AMOGUS",
                CdnBaseUri = "http://localhost:56703/",
                LevelProgressionMaps = new List<LevelMap>()
                {
                    new LevelMap
                    {
                        Level = 0,
                        RequiredXp = 0

                    },
                    new LevelMap
                    {
                        Level = 1,
                        RequiredXp = 10

                    },
                    new LevelMap
                    {
                        Level = 2,
                        RequiredXp = 10

                    },
                    new LevelMap
                    {
                        Level = 3,
                        RequiredXp = 20

                    },
                    new LevelMap
                    {
                        Level = 4,
                        RequiredXp = 20

                    },
                    new LevelMap
                    {
                        Level = 5,
                        RequiredXp = 30

                    },
                    new LevelMap
                    {
                        Level = 6,
                        RequiredXp = 30

                    },
                    new LevelMap
                    {
                        Level = 7,
                        RequiredXp = 40

                    },
                    new LevelMap
                    {
                        Level = 8,
                        RequiredXp = 40

                    },
                    new LevelMap
                    {
                        Level = 9,
                        RequiredXp = 45

                    },
                    new LevelMap
                    {
                        Level = 10,
                        RequiredXp = 50

                    },
                    new LevelMap
                    {
                        Level = 11,
                        RequiredXp = 50

                    },
                    new LevelMap
                    {
                        Level = 12,
                        RequiredXp = 60

                    },
                    new LevelMap
                    {
                        Level = 13,
                        RequiredXp = 60

                    },
                    new LevelMap
                    {
                        Level = 14,
                        RequiredXp = 70

                    },
                    new LevelMap
                    {
                        Level = 15,
                        RequiredXp = 70

                    },
                    new LevelMap
                    {
                        Level = 16,
                        RequiredXp = 80

                    },
                    new LevelMap
                    {
                        Level = 17,
                        RequiredXp = 80

                    },
                    new LevelMap
                    {
                        Level = 18,
                        RequiredXp = 90

                    },
                    new LevelMap
                    {
                        Level = 19,
                        RequiredXp = 90

                    },
                    new LevelMap
                    {
                        Level = 20,
                        RequiredXp = 100

                    },
                    new LevelMap
                    {
                        Level = 21,
                        RequiredXp = 100

                    },
                    new LevelMap
                    {
                        Level = 22,
                        RequiredXp = 110

                    },
                    new LevelMap
                    {
                        Level = 23,
                        RequiredXp = 110

                    },
                    new LevelMap
                    {
                        Level = 24,
                        RequiredXp = 120

                    },
                    new LevelMap
                    {
                        Level = 25,
                        RequiredXp = 120

                    },
                    new LevelMap
                    {
                        Level = 26,
                        RequiredXp = 130

                    },
                    new LevelMap
                    {
                        Level = 27,
                        RequiredXp = 130

                    },
                    new LevelMap
                    {
                        Level = 28,
                        RequiredXp = 140

                    },
                    new LevelMap
                    {
                        Level = 29,
                        RequiredXp = 140

                    },
                    new LevelMap
                    {
                        Level = 30,
                        RequiredXp = 150

                    },
                },
                MatchmakingParams = new MatchPrams
                {
                    PreferEmptyRoomsFrequency = 0f,
                    PreferFullRoomsFrequency = 1f
                },
                ServerMaintainence = new ServerMaintainence
                {
                    StartsInMinutes = 0
                },
                DailyObjectives = new Objective[][]
                {
                    new Objective[]
            {
                new Objective
                {
                    type = 20,
                    score = 1
                },
                new Objective
                {
                    type = 21,
                    score = 1
                },
                new Objective
                {
                    type = 22,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = 32,
                    score = 1
                },
                new Objective
                {
                    type = 21,
                    score = 1
                },
                new Objective
                {
                    type = 22,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = 20,
                    score = 1
                },
                new Objective
                {
                    type = 21,
                    score = 1
                },
                new Objective
                {
                    type = 22,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = 20,
                    score = 1
                },
                new Objective
                {
                    type = 21,
                    score = 1
                },
                new Objective
                {
                    type = 22,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = 20,
                    score = 1
                },
                new Objective
                {
                    type = 21,
                    score = 1
                },
                new Objective
                {
                    type = 22,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = 20,
                    score = 1
                },
                new Objective
                {
                    type = 21,
                    score = 1
                },
                new Objective
                {
                    type = 22,
                    score = 1
                }
            },
            new Objective[]
            {
                new Objective
                {
                    type = 20,
                    score = 1
                },
                new Objective
                {
                    type = 21,
                    score = 1
                },
                new Objective
                {
                    type = 22,
                    score = 1
                }
            }
        },
                ConfigTable = new List<CTable>
                {
                    new CTable
                    {
                        Key = "Gift.DropChance",
                        Value = 0.5f.ToString()
                    },
                    new CTable
                    {
                        Key = "Gift.Xp",
                        Value = 0.5f.ToString()
                    }
                },
                PhotonConfig = new PhotonConfig
                {
                    CloudRegion = "us",
                    CrcCheckEnabled = false,
                    EnableServerTracingAfterDisconnect = false
                }



            };
            return JsonConvert.SerializeObject(result);
        }
    }
    public class ConfigClass
    {
        public string MessageOfTheDay { get; set; }
        public string CdnBaseUri { get; set; }
        public List<LevelMap> LevelProgressionMaps { get; set; }
        public MatchPrams MatchmakingParams { get; set; }
        public ServerMaintainence ServerMaintainence { get; set; }
        public Objective[][] DailyObjectives { get; set; }
        public List<CTable> ConfigTable { get; set; }
        public PhotonConfig PhotonConfig { get; set; }

    
    }
    public class LevelMap
    {
        public int Level { get; set; }
        public int RequiredXp { get; set; }
    }
    public class MatchPrams
    {
        public float PreferFullRoomsFrequency { get; set; }
        public float PreferEmptyRoomsFrequency { get; set; }
    }
    public class Objective
    {
        public int type { get; set; }
        public int score { get; set; }
    }
    public class CTable
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class PhotonConfig
    {
        public string CloudRegion { get; set; }
        public bool CrcCheckEnabled { get; set; }
        public bool EnableServerTracingAfterDisconnect { get; set; }
    }
    public class ServerMaintainence
    {
        public int StartsInMinutes { get; set; }
    }

}
