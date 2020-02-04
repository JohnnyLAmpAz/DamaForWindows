using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DamaLib.Models.BackEnd.Core
{
    class DiscoveryServerUDP
    {
        const string response = "HereIAm!";
        const string rightRequest = "DamaServerDiscoveryRequest";

        Thread discoveryServerThread;

        public DiscoveryServerUDP()
        {
            discoveryServerThread = new Thread(() => 
            {
                UdpClient udpClient = new UdpClient(Constants.DamaServerPort);
                IPEndPoint client;

                // Loop infinito di ascolto
                while (true)
                {
                    // Reset client IPEndPoint
                    client = new IPEndPoint(IPAddress.Any, 0);

                    // Ricevo richiesta e ne salvo la stringa
                    string req = Encoding.UTF8.GetString(
                        udpClient.Receive(ref client));

                    /* Controllo se la richiesta rispecchia il protocollo 
                     * di discovery e, in tal caso, rispondo. 
                     * 
                     * Ref ./protocol.md 
                     */
                    if (req.Equals(rightRequest))
                    {
                        byte[] buff = Encoding.UTF8.GetBytes(response);
                        udpClient.Send(buff, buff.Length, client);
                    }
                }
            });
            discoveryServerThread.Start();
        }
    }
}
