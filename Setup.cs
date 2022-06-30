using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading;
using Newtonsoft.Json;

namespace CoffeeVault2
{
    internal class Setup
    {
        public static void SetupGUI()
        {
            Console.WriteLine("Welcome to CoffeeVault! Before the server can start, we need to ask you a few questions.\nPress Enter to Continue...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ok. First, what will you like to be your username in game?");
            var username = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Now, what do you want your DisplayName in game? (leave blank for your username)");
            var display = Console.ReadLine();
            if (display == "")
            {
                display = username;
            }
            Console.Clear();
            Console.WriteLine("Ok, " + display + ", we are done with questions. Now it's time for the fun generation of stuff.\nPress Enter to Continue...");
            Console.ReadLine();
            Console.Clear();
            SetupFiles(username, display);
            
            
            
        }
        public static void SetupFiles(string username, string display)
        {
            Console.WriteLine("Generateing Player and PlatformLogin Info...");
            Player player = new Player()
            {
                Id = (ulong)new Random().Next(100000000, 999999999),
                Username = username,
                DisplayName = display,
                Bio = "",
                XP = 0,
                Level = 5,
                RegistrationStatus = 2,
                Developer = true,
                CanReceiveInvites = false,
                ProfileImageName = "CVProfileImage",
                JuniorProfile = false,
                ForceJuniorImages = false,
                PendingJunior = false,
                HasBirthday = true,
                AvoidJuniors = true,
                PlayerReputation = new Reputation()
                {
                    Noteriety = 0,
                    CheerGeneral = 0,
                    CheerHelpful = 0,
                    CheerGreatHost = 0,
                    CheerSportsman = 0,
                    CheerCreative = 0,
                    CheerCredit = 0,
                    SelectedCheer = 0,
                    SubscriberCount = 0,
                    SubscribedCount = 0
                },
                PlatformIds = new List<PlatformIds>
                {
                    new PlatformIds
                    {
                        Platform = 0,
                        PlatformId = 76561198243518990
                    }
                }

            };
            
            
            Console.WriteLine("Player Data Declared! Declaring AvatarData...");
            Avatar avatar = new Avatar()
            {
                OutfitSelections = "b33dbeee-5bdd-443d-aa6a-761248054e08,,,,1;6d48c545-22bb-46c1-a29d-0a38af387143,,,,2;6d48c545-22bb-46c1-a29d-0a38af387143,,,,3;ecc1dbe6-ca06-4564-b2a6-30956194d1e9,51ef8d39-2b94-4f9e-9620-07b6b0a913a5,0b2395e1-ebcc-47e9-aaf1-faf9e9cec4cd,,2;ecc1dbe6-ca06-4564-b2a6-30956194d1e9,51ef8d39-2b94-4f9e-9620-07b6b0a913a5,0b2395e1-ebcc-47e9-aaf1-faf9e9cec4cd,,3;7b857a8c-92ad-4028-a2c2-b3c20cdab5f2,51ef8d39-2b94-4f9e-9620-07b6b0a913a5,0b2395e1-ebcc-47e9-aaf1-faf9e9cec4cd,,1;14ef6b00-debf-4a85-9755-b4d37df496d3,51ef8d39-2b94-4f9e-9620-07b6b0a913a5,,,0;",
                HairColor = "3Q8U6E5pV0uzK141ut2WBg",
                SkinColor = "4fb0fdbd-b10a-492e-8df2-b43f981b2ce6",
                FaceFeatures = "{\"ver\":3,\"eyeId\":\"AjGMoJhEcEehacRZjUMuDg\",\"eyePos\":{\"x\":0.009999999776482582,\"y\":0.0},\"eyeScl\":0.0,\"mouthId\":\"bGkb3uJ26UWATP52wNCetw\",\"mouthPos\":{\"x\":0.0,\"y\":0.0},\"mouthScl\":0.0,\"beardColorId\":\"3Q8U6E5pV0uzK141ut2WBg\"}"
            };
            Console.WriteLine("Avatar Data declared! Creating Files and Directories...");
            if (!Directory.Exists(Program.path + "\\ServerData"))
            {
                Directory.CreateDirectory(Program.path + "\\ServerData");
            }
            File.WriteAllText(Program.path + "\\ServerData\\Player.json", JsonConvert.SerializeObject(player));
            File.WriteAllText(Program.path + "\\ServerData\\Avatar.json", JsonConvert.SerializeObject(avatar));
            Console.Clear();
            Console.WriteLine("All Files and Directoies Created! I hope you have fun in CoffeeVault! (CoffeeVault will restart in 4 seconds.)");
            Thread.Sleep(4000);
            Console.Clear();
            Process.Start(Program.path + "\\CoffeeVault.exe");
            Environment.Exit(0);
        }
    }
}
