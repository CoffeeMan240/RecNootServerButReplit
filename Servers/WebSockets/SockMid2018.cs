using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace CoffeeVault2.Servers.WebSockets
{
    internal class SockMid2018
    {
        public static WebSocketServer WebSocket = new WebSocketServer("ws://localhost:56701/");
        public SockMid2018()
        {
            WebSocket.AddWebSocketService<Hub>("/hub/v1");
            WebSocket.AddWebSocketService<Notification>("/api/notification/v2");
            WebSocket.Start();
            
            
            Console.WriteLine("[WS] WebSocket Server Started!");
        }
    }
    public class Hub : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            base.Send(JsonConvert.SerializeObject(new HubData()
            {
                accessToken = "AccessRecNoot",
                url = new Uri("ws://localhost:56701/"),
                SupportedTransports = new List<string>(),
                negotiateVersion = 0,
            }));
        }
        
    }
    public class HubData
    {
        public Uri url { get; set; }
        public string accessToken { get; set; }
        public List<string> SupportedTransports { get; set; }
        public int negotiateVersion { get; set; }
    }
    public class Notification : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            
            base.Send(NotifMid2018.Request(e.Data));
        }
    }
}
