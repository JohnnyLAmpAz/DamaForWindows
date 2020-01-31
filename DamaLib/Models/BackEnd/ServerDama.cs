using System;
using System.Collections.Generic;
using System.Text;
using DamaLib.Models.BackEnd.Core;

namespace DamaLib.Models.BackEnd
{
    class ServerDama : TcpServer
    {
        DiscoveryServerUDP discoveryServer;
        public ServerDama() : base(55555)
        {
            // Avvio il server UDP di discovery
            discoveryServer = new DiscoveryServerUDP();
        }

        public override string Handler(string req)
        {
            return "";
        }
    }
}
