using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace victim
{
    class Program
    {
        private static Queue<DateTime> connections;
        private static Socket botComm;
        private static string password;

        private static void init()
        {
            connections = new Queue<DateTime>();
            botComm = new Socket(SocketType.Stream, ProtocolType.Tcp);
            char[] charPass = new char[6];
            Random r = new Random();
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            for(int i=0; i<charPass.Length; i++)
            {
                charPass[i] = chars[r.Next(chars.Length)];
            }
            password = new string(charPass);
        }

        private static void listenBots()
        {
            while (!botComm.Connected) ;
            string sendPass = "Please enter your password\r\n";
            byte[] b = Encoding.ASCII.GetBytes(sendPass);

        }

        static void Main(string[] args)
        {
            init();
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress myIP = null;
            foreach (IPAddress addr in localIPs)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = addr;
                }
            }
            Random r = new Random();
            IPEndPoint e = new IPEndPoint(myIP, r.Next(1024, 65535));
            botComm.Bind(e);
            int myPort = e.Port;
            Console.WriteLine("Server listening on port "+myPort+", password is " + password);
            Thread listenToBots = new Thread(new ThreadStart(listenBots));
        }
    }
}
