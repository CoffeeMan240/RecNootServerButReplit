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
    internal class SockLate2018
    {
        public static WebSocketServer WebSocket = new WebSocketServer("ws://localhost:56701/");
        public SockLate2018()
        {
            WebSocket.AddWebSocketService<Hub>("/hub/v1");
            WebSocket.AddWebSocketService<Notification18>("/api/notification/v2");
            WebSocket.Start();
            Console.WriteLine("[WS] WebSocket Server Started!");
        }
    }
    
    
    public class Notification18 : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            base.Send(NotifLate2018.Request(e.Data));
        }
    }
}
