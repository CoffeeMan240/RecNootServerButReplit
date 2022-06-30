using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Principal;
using Newtonsoft.Json;

namespace CoffeeVault2
{
    internal class Program
    {
        public static string path = Environment.CurrentDirectory;
        public static string fullpath = path + "\\ServerData";
        public static Player player;
        static void Main(string[] args)
        {
            if (!Directory.Exists(path + "\\ServerData"))
            {
                Setup.SetupGUI();
            }
            else
                
            Console.Title = "RecNootServer";
            Console.WriteLine("Welcome To RecNootServer!");
            Console.WriteLine("Choose an option.");
            Console.WriteLine("[1} Start Server\n[2} Configure Settings\n[3} Credits");
            string readline = Console.ReadLine();
            if (readline == "1")
            {
                Console.Clear();
                Console.WriteLine("Ok! Select a year to play.");
                Console.WriteLine("[1} 2018\n[2} 2017 \n[3} 2016\n[4} VaultServer Mode (Requires Admin)");
                var readline2readharder = Console.ReadLine();
                if (readline2readharder == "1") 
                {
                    Console.WriteLine("Starting Servers...");
                    new Servers.API.APIMid2018();
                    new Servers.WebSockets.SockMid2018();
                    new Servers.Name.Name();
                    Console.WriteLine("Servers Started!");
                }
                else
                if (readline2readharder == "2")
                {
                    Console.WriteLine("Not Implemented Yet!");
                }
                else
                if (readline2readharder == "3")
                {
                    Console.WriteLine("Not Implemented Yet!");
                }
                else
                if (readline2readharder == "4")
                {
                    Console.WriteLine("VS Not Implemented Yet!");
                }
                if (readline2readharder == "2019")
                {
                    Console.WriteLine("2019 Not Implemented Yet!");
                }
            }
            else
            if (readline == "2")
            {
                Console.WriteLine("Not Implemented Yet!");
            }
            if (readline == "3")
            {
                Console.WriteLine("Not Implemented Yet!");
            }
        }
    }
}
