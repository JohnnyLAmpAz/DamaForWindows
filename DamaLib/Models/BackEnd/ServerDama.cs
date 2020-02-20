using DamaLib.Models.BackEnd.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DamaLib.Models.BackEnd
{
    public class ServerDama : TcpServer
    {
        DiscoveryServerUDP discoveryServer;
        List<Lobby> lobbies;
        List<Scacchiera> partite;

        public ServerDama() : base(Constants.DamaServerPort)
        {
            // Avvio il server UDP di discovery
            discoveryServer = new DiscoveryServerUDP();
            lobbies = new List<Lobby>();
            partite = new List<Scacchiera>();
        }

        public override string Handler(string req, IPEndPoint client)
        {
            #region Non-JSON requests

            // ListAvailableLobbies
            if (req.Equals(Constants.Requests.GetListAvailableLobbies))
                return JsonConvert.SerializeObject(lobbies);

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
                    if (lobbies.Exists((x) => x.Creatore.Equals(client.Address.ToString())))
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
                    if (l == default(Lobby))
                        return Constants.ResponseErrors.LobbyNameNotFound.ToString();

                    // Controllo che colui che la vuole eliminare sia il creatore
                    if (!l.Creatore.Equals(client.Address.ToString()))
                        return Constants.ResponseErrors.LobbyCreatorRequired.ToString();

                    // Elimino la lobby
                    lobbies.RemoveAll(x => x.Nome.Equals(nome));
                    return Constants.Responses.Ok;
                }

                // JoinLobby
                if (((string)json["req"]).Equals(Constants.Requests.JoinLobby))
                {
                    string nomeLobby = (string)json["nome"];
                    Lobby lobby = lobbies.Find(x => x.Nome.Equals(nomeLobby));

                    // Controllo che la lobby esista
                    if (lobby == default(Lobby))
                        return Constants.ResponseErrors.LobbyNameNotFound.ToString();

                    // Controllo che questa lobby sia disponibile
                    if (!(lobby.Unito is null))
                        return Constants.ResponseErrors.LobbyNotAvailable.ToString();

                    // TODO: Controlla anche che non stia già giocando o già hostando una lobby!

                    // Avverti il creatore
                    JObject jsonRes = new JObject();
                    jsonRes.Add("type", new JValue(Constants.LocalRequests.LobbyPlayerJoined));
                    jsonRes.Add("player", new JValue(client.Address.ToString()));
                    TcpRequest(jsonRes.ToString(), client.Address);

                    // Aggiungo lo sfidante
                    lobby.Unito = client.Address.ToString();
                    return JsonConvert.SerializeObject(lobby);
                }

                // LeaveLobby
                if (((string)json["req"]).Equals(Constants.Requests.LeaveLobby))
                {
                    string nomeLobby = (string)json["nome"];

                    // Controllo se esiste la lobby
                    if (!lobbies.Exists(x => x.Nome.Equals(nomeLobby)))
                        return Constants.ResponseErrors.LobbyNameNotFound.ToString();

                    // Controllo che sia il giocatore ospite della lobby
                    Lobby l = lobbies.Find(x => x.Nome.Equals(nomeLobby));
                    if (!l.Unito.Equals(client.Address.ToString()))
                        return Constants.ResponseErrors.NotPartecipant.ToString();

                    // Leave
                    l.Unito = null;

                    // TODO: notifica il creatore 

                    return Constants.Responses.Ok;
                }
            }
            catch (JsonReaderException)
            {
                return Constants.ResponseErrors.InvalidRequest.ToString();
            }

            #endregion

            return Constants.ResponseErrors.InvalidRequest.ToString();

        }
        private string TcpRequest(string req, IPAddress ipClient)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(new IPEndPoint(ipClient, Constants.DamaLocalServerPort));
            NetworkStream ns = tcpClient.GetStream();

            // Request
            byte[] buff = Encoding.UTF8.GetBytes(req);
            ns.Write(buff, 0, buff.Length);

            // Response
            buff = new byte[tcpClient.ReceiveBufferSize];
            int len = ns.Read(buff, 0, tcpClient.ReceiveBufferSize);

            tcpClient.Close();

            return Encoding.UTF8.GetString(buff, 0, len);
        }
    }
}
