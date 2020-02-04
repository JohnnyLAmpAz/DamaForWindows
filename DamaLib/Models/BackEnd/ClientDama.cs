﻿using DamaLib.Models.BackEnd.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DamaLib.Models.BackEnd
{
    public class ClientDama
    {
        public IPAddress Server { get; set; } = default;
        TcpClient tcpClient;

        public List<Lobby> GetListAvailableLobbies()
        {
            return JsonConvert.DeserializeObject<List<Lobby>>(
                TcpRequest(Constants.Requests.GetListAvailableLobbies));
        }

        public bool DiscoverServer()
        {
            UdpClient udpClient;
            byte[] buff;
            IPEndPoint server;

            while (true)
            {
                try
                {
                    udpClient = new UdpClient();

                    // Setto come destinatario indirizzo broadcast
                    server = new IPEndPoint(IPAddress.Broadcast, Constants.DamaServerPort);

                    // Richiesta
                    buff = Encoding.UTF8.GetBytes("DamaServerDiscoveryRequest");
                    udpClient.Send(buff, buff.Length, server);

                    // Catch risposta e mi salvo l'IP del server
                    udpClient.Client.ReceiveTimeout = 5000;
                    buff = udpClient.Receive(ref server);
                    break;
                }
                catch (SocketException e)
                {
                    if (e.ErrorCode.Equals(10060))
                    {
                        // If receive timed-out retry
                        continue;
                    }
                    else
                        throw e;
                }
            }

            udpClient.Close();

            if (Encoding.UTF8.GetString(buff).Equals("HereIAm!"))
            {
                // Mi salvo l'indirizzo
                Server = server.Address;

                return true;    // Trovato
            }
            else
                return false;   // Non trovato
        }

        public string CreateLobby(string nome)
        {
            JObject json = new JObject();
            json.Add("req", new JValue(Constants.Requests.CreateLobby));
            json.Add("nome", new JValue(nome));
            return TcpRequest(json.ToString());
        }

        /// <summary>
        /// Richiesta TCP al server alla porta definita nelle costanti
        /// </summary>
        /// <param name="req">Stringa di richiesta</param>
        /// <returns>Stringa di risposta</returns>
        private string TcpRequest(string req)
        {
            tcpClient = new TcpClient();

            tcpClient.Connect(new IPEndPoint(Server, Constants.DamaServerPort));
            NetworkStream ns = tcpClient.GetStream();

            // Request
            byte[] buff = Encoding.UTF8.GetBytes(req);
            ns.Write(buff, 0, buff.Length);

            // Response
            buff = new byte[tcpClient.ReceiveBufferSize];
            int len = ns.Read(buff, 0, tcpClient.ReceiveBufferSize);

            tcpClient.Close();

            return Encoding.UTF8.GetString(buff,0,len);
        }
    }
}