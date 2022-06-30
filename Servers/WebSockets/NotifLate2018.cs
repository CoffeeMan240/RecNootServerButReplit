using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RecNootServer;

namespace CoffeeVault2.Servers.WebSockets
{
    internal class NotifLate2018
    {
        public static string Request(string post)
        {
            Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(post);
            string result = "";
            if (data.ContainsKey("api"))
            {
                string request = (string)data["api"];
                if(request != null)
                {
                    if (request == "playerSubscriptions/v1/update")
                    {
                        Console.WriteLine("[WS] Presence Update Requested.");
                        result = JsonConvert.SerializeObject(new Respond()
                        {
                            Id = 12,
                            Msg = GameSessionsV3.PresenceV3()
                        });
                        goto Return;
                    }
                    if (request == "heartbeat2")
                    {
                        Console.WriteLine("[WS] Heartbeat Requested.");
                        result = JsonConvert.SerializeObject(new Respond()
                        {
                            Id = 4,
                            Msg = GameSessionsV3.PresenceV3()
                        });
                        goto Return;
                    }
                }
                Console.WriteLine("[WS] Unknown Call.");
            Return:;

            }
            else
            {
                Console.WriteLine("[WS] Unknown URL: " + JsonConvert.SerializeObject(data.ToList()));
                result = post;
            }
            return result;
        }
        public class Respond
        {
            public int Id { get; set; }
            public object Msg { get; set; }
        }
       
    }
}
