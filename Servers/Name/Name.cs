using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading;
using Newtonsoft.Json;

namespace CoffeeVault2.Servers.Name
{
    internal class Name
    {
        
        public static HttpListener Server = new HttpListener();
        public Name()
        {
            try
            {
                Console.WriteLine("NameServer Started!");
                new Thread(new ThreadStart(Listen)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("NameServer Failed! " + ex.ToString());
                
            }
            
        }
        public static void Listen()
        {
            Server.Prefixes.Add("http://localhost:20181/");
            
            for(; ; )
            {
                Server.Start();
                HttpListenerContext context = Server.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse responce = context.Response;
                string rawurl = request.RawUrl;
                string r;
                string post;
                string currenttime = DateTime.Now.ToString();
                Console.WriteLine("[" + currenttime + "] NameServer Requested.");
                using (StreamReader streamReader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    post = streamReader.ReadToEnd();
                }
                if (rawurl.StartsWith("/"))
                {
                    r = JsonConvert.SerializeObject(new LSDAgain()
                    {
                        API = "http://localhost:56700/",
                        
                        Images = "https://img.rec.net/"
                    });
                    goto SendAndClose;
                }
                else
                {
                    r = "[]";
                }
                SendAndClose:
                byte[] bytes = Encoding.UTF8.GetBytes(r);
                responce.ContentLength64 = bytes.Length;
                Stream outputstream = responce.OutputStream;
                outputstream.Write(bytes, 0, bytes.Length);
                Thread.Sleep(500);
                Server.Stop();

            }
        }
    }
    public class LSDAgain
    {
        public string API { get; set; }
        //public string Notifications { get; set; }
        public string Images { get; set; }
    }
}
