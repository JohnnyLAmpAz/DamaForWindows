using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DamaLib.Models.BackEnd.Core
{
    public abstract class TcpServer
    {
        TcpListener lis;
        public TcpServer(int port)
        {
            lis = new TcpListener(IPAddress.Any, port);
            Thread t = new Thread(new ThreadStart(() =>
            {
                StartListener();
            }));
            t.IsBackground = true;
            t.Start();
        }

        private void StartListener()
        {
            try
            {
                lis.Start();
                while (true)
                {
                    TcpClient c = lis.AcceptTcpClient();
                    Thread tClient = new Thread(new ThreadStart(() =>
                    {
                        TcpClient client = c;
                        Console.WriteLine($"{client.Client.RemoteEndPoint.ToString()} connected");

                        NetworkStream ns = client.GetStream();
                        byte[] buff = new byte[1024];
                        int i = ns.Read(buff, 0, buff.Length);
                        while (i != 0)
                        {
                            string req = Encoding.ASCII.GetString(buff, 0, i);
                            Console.WriteLine($"<{client.Client.RemoteEndPoint.ToString()}>: {req}");
                            buff = Encoding.ASCII.GetBytes(
                                Handler(req,(IPEndPoint)client.Client.RemoteEndPoint));
                            ns.Write(buff, 0, buff.Length); //Risposta
                            buff = new byte[1024];
                            i = ns.Read(buff, 0, buff.Length);
                        }
                        Console.WriteLine($"{client.Client.RemoteEndPoint.ToString()} disconnected");
                        client.Close();
                    }));
                    tClient.Start();
                }
            }
            catch (Exception e)
            {
                lis.Stop();
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Metodo da implementare che gestisce la richiesta e ritorna la risposta
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public abstract string Handler(string req, IPEndPoint client);
    }
}
