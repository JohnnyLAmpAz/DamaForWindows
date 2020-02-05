using DamaLib.Models.BackEnd.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

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
                    if (string.IsNullOrWhiteSpace(nomeLobby))
                        return Constants.ResponseErrors.LobbyNameNotValid.ToString();
                    if (lobbies.Exists((x) => x.Nome.Equals(nomeLobby)))
                        return Constants.ResponseErrors.LobbyNameInUse.ToString();

                    // TODO: Controlla anche che non stia già giocando!

                    // Creo una lobby
                    lobbies.Add(new Lobby(client.Address.ToString(), nomeLobby));
                    return Constants.Responses.Ok;
                }

                // DeleteLobby
                if (((string)json["req"]).Equals(Constants.Requests.DeleteLobby))
                {
                    string nome = (string)json["nome"];
                    // Cerco la lobby
                    Lobby l = lobbies.Find(x => x.Nome.Equals(nome));
                    if (l == default)
                        return Constants.ResponseErrors.LobbyNameNotFound.ToString();

                    // Controllo che colui che la vuole eliminare sia il creatore
                    if (!l.Creatore.Equals(client.Address.ToString()))
                        return Constants.ResponseErrors.LobbyCreatorRequired.ToString();

                    // Elimino la lobby
                    lobbies.RemoveAll(x => x.Nome.Equals(nome));
                    return Constants.Responses.Ok;
                }
            }
            catch (JsonReaderException) { }

            #endregion

            return Constants.ResponseErrors.InvalidRequest.ToString();
        }

        private string ListAvailableLobbies()
        {
            return JsonConvert.SerializeObject(lobbies);
        }
    }
}
