using DamaLib.Models.BackEnd.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DamaLib.Models.BackEnd
{
    public class LocalServerOnClient : TcpServer
    {
        public LocalServerOnClient(int port) : base(port)
        {
        }

        public override string Handler(string req, IPEndPoint client)
        {
            try
            {
                JObject json = JObject.Parse(req);

                // LobbyPlayerJoined
                if (((string)json["type"]).Equals(Constants.LocalRequests.LobbyPlayerJoined))
                    OnOtherLobbyPlayerJoined(new OtherLobbyPlayerJoinedEventArgs()
                    {
                        IpUnito = client.Address.ToString()
                    });
            }
            catch (JsonReaderException) { }

            // TODO: find another solution
            return "";
        }

        protected void OnOtherLobbyPlayerJoined(OtherLobbyPlayerJoinedEventArgs e)
        {
            //EventHandler<OtherLobbyPlayerJoinedEventArgs> handler = OtherLobbyPlayerJoined;
            //if (handler != null)
            //    handler(this, e);
            // SAME AS...
            OtherLobbyPlayerJoined?.Invoke(this, e);
        }

        public event EventHandler<OtherLobbyPlayerJoinedEventArgs> OtherLobbyPlayerJoined;
    }
}
