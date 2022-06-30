using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading;
using RecNootServer;

namespace CoffeeVault2.Servers.API
{
    internal class APILate2018
    {
        
        public static HttpListener Server = new HttpListener();
        public APILate2018()
        {
            try
            {
                Console.WriteLine("[API] Late 2018 Server Started!");
                new Thread(new ThreadStart(Listen)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[API] Late 2018 Server Failed! " + ex.ToString());
                
            }
            
        }
        public static void Listen()
        {
            Server.Prefixes.Add("http://localhost:56700/");
            for(; ; )
            {
                Server.Start();
                HttpListenerContext context = Server.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse responce = context.Response;
                string rawurl = request.RawUrl;
                string r;
                string post;
                
                Console.WriteLine("[API] Late 2018 Requested URL " + context.Request.Url);
                
                foreach(string key in context.Request.Headers.AllKeys)
                {
                    Console.WriteLine(key + " : " + context.Request.Headers.GetValues(key).First());
                }
                
                using (StreamReader streamReader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    post = streamReader.ReadToEnd();
                }
                if (rawurl.StartsWith("/api/testing/v2"))
                {
                    r = "A COFFEE MUG, A MELON, and a REPORT BUTTON";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/noot/v1/status"))
                {
                    r = "Online, dummy.";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/versioncheck/"))
                {
                    r = "{\"ValidVersion\":true}";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/config/v2"))
                {
                    r = Config.GetConfig();
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/platformlogin/v1/getcachedlogins"))
                {
                    r = "[" + File.ReadAllText(Program.fullpath + "\\Player.json") + "]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/platformlogin/v1/logincached"))
                {
                    r = PlatformLoginLogic.loginCached();
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/PlayerReporting/v1/moderationBlockDetails"))
                {
                    r = "{\"ReportCatagory\":0,\"Duration\":0,\"GameSessionId\":0,\"Message\":\"\"}";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/testing/v2"))
                {
                    r = "A COFFEE MUG, A MELON, and a REPORT BUTTON";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/presence/v2/setscreenmode"))
                {
                    r = post;
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/presence/v2/setscreenmode"))
                {
                    r = post;
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/config/v1/amplitude"))
                {
                    r = "{\"AmplitudeKey\":\"RecNoot\"}";
                    goto SendAndClose;
                }
                else
                 if (rawurl.StartsWith("/api/avatar/v2/gifts"))
                {
                    r = "[]";
                    goto SendAndClose;
                }
                else
                 if (rawurl.StartsWith("/api/avatar/v2/set"))
                {
                    Saving.SaveAvatar(post, "","");
                    r = "";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/avatar/v2"))
                {
                    
                    r = File.ReadAllText(Program.fullpath + "\\Avatar.json");
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/messages/v2/get"))
                {
                    
                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/chat/v2/myChats?mode=0&count=50"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/relationships/v2/get"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/settings/v2/set"))
                {

                    r = "";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/settings/v2"))
                {

                    r = File.ReadAllText(Program.fullpath + "\\Settings.json");
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/avatar/v3/items"))
                {

                    r = File.ReadAllText(Program.fullpath + "\\AvatarItems.json");
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/avatar/v3/items"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/avatar/v3/items"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/equipment/v1/getUnlocked"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/chat/v2/myChats"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/playersubscriptions/v1/my"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/consumables/v1/getUnlocked"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/storefronts/v3/giftdropstore/3"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/storefronts/v3/giftdropstore/2"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/objectives/v1/myprogress"))
                {

                    r = File.ReadAllText(Program.fullpath + "\\Progress.json");
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/checklist/v1/current"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/events/v3/list"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/playerevents/v1/all"))
                {

                    r = "{\"Created\":[],\"Responses\":[]}";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/rooms/v2/myrooms"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/activities/charades/v1/words"))
                {

                    r = File.ReadAllText(Program.fullpath + "\\Charades.json"); ;
                    goto SendAndClose;
                }
                else
                 if (rawurl.StartsWith("/api/challenge/v1/getCurrent"))
                {

                    r = "[]";
                    goto SendAndClose;
                }
                else
                 if (rawurl.StartsWith("/api/gamesessions/v3/joinroom"))
                {
                    //oh shit oh fuck pt 2
                    r = GameSessionsV3.joinRoom(post);
                    goto SendAndClose;
                }
                else
                if (rawurl.StartsWith("/api/gameconfigs/v1/all"))
                {

                    r = File.ReadAllText(Program.fullpath + "\\gameconfig.json");
                    goto SendAndClose;
                }
                else
                {
                    Console.WriteLine("Unknown API Call! Returning empty list. ");
                    r = "[]";
                    goto SendAndClose;
                }
                SendAndClose:
                Console.WriteLine("Post Data: " + post);
                byte[] bytes = Encoding.UTF8.GetBytes(r);
                responce.ContentLength64 = bytes.Length;
                Stream outputstream = responce.OutputStream;
                outputstream.Write(bytes, 0, bytes.Length);
                Thread.Sleep(200);
                Server.Stop();

            }
        }
    }
}
