using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DamaLib.Models.BackEnd.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DamaLib.Models.BackEnd
{
    public class ServerDama : TcpServer
    {
        DiscoveryServerUDP discoveryServer;
        List<Lobby> lobbies;

        public ServerDama() : base(Constants.DamaServerPort)
        {
            // Avvio il server UDP di discovery
            discoveryServer = new DiscoveryServerUDP();
            lobbies = new List<Lobby>();
        }

        public override string Handler(string req, IPEndPoint client)
        {
            #region Non-JSON requests

            // ListAvailableLobbies
            if (req.Equals(Constants.Requests.GetListAvailableLobbies))
                return ListAvailableLobbies();

            #endregion

            #region JSON requests

            JObject json;
            try
            {
                json = JObject.Parse(req);

                // CreateLobby
                if (((string)json["req"]).Equals(Constants.Requests.CreateLobby))
                {
                    // Controllo che questo client non abbia già creato una lobby
                    if (lobbies.Exists((x) => x.Creatore.Equals(client.Address)))
                        return Constants.ResponseErrors.LobbyAlreadyCreated.ToString();

                    // Controllo che il nome della lobby sia valido e che non sia già in uso
                    string nomeLobby = (string)json["nome"];
                    if (string.IsNullOrWhiteSpace(nomeLobby) || 
                        lobbies.Exists((x) => x.Nome.Equals(nomeLobby)))
                        return Constants.ResponseErrors.LobbyNameInUse.ToString();

                    // TODO: Controlla anche che non stia già giocando!

                    // Creo una lobby
                    lobbies.Add(new Lobby(client.Address.ToString(), nomeLobby));
                    return Constants.Responses.Ok;
                }


            }
            catch (JsonReaderException) {}

            #endregion

            return Constants.ResponseErrors.InvalidRequest.ToString();
        }

        private string ListAvailableLobbies()
        {
            return JsonConvert.SerializeObject(lobbies);
        }
    }
}
