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

                // LobbyPlayerLeft
                if (((string)json["type"]).Equals(Constants.LocalRequests.LobbyPlayerLeft))
                    OnOtherLobbyPlayerLeft();
            }
            catch (JsonReaderException) { }

            return Constants.Responses.Ok;
        }

        protected void OnOtherLobbyPlayerJoined(OtherLobbyPlayerJoinedEventArgs e)
        {
            //EventHandler<OtherLobbyPlayerJoinedEventArgs> handler = OtherLobbyPlayerJoined;
            //if (handler != null)
            //    handler(this, e);
            // SAME AS...
            OtherLobbyPlayerJoined?.Invoke(this, e);
        }
        protected void OnOtherLobbyPlayerLeft() => OtherLobbyPlayerLeft?.Invoke(this,new EventArgs());

        public event EventHandler<OtherLobbyPlayerJoinedEventArgs> OtherLobbyPlayerJoined;
        public event EventHandler OtherLobbyPlayerLeft;
    }
}
