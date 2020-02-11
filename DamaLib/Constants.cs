using System;
using System.Collections.Generic;
using System.Text;

namespace DamaLib
{
    public static class Constants
    {
        #region Definizioni
        public struct Error
        {
            public string Code { get; set; }
            public string Message { get; set; }

            public override string ToString() => $"{Code} - {Message}";
        }

        #endregion

        public static int DamaServerPort = 55555;
        public static class Requests
        {
            public const string GetListAvailableLobbies = "ListAvailableLobbies";
            public const string CreateLobby = "CreateLobby";
            public const string DeleteLobby = "DeleteLobby";
            public const string JoinLobby = "JoinLobby";
            public const string LeaveLobby = "LeaveLobby";
        }
        public static class Responses
        {
            public const string Ok = "OK";
        }
        public static class ResponseErrors
        {
            public static readonly Error InvalidRequest = new Error
            {
                Code = "E0",
                Message = "Invalid Request"
            };
            public static readonly Error LobbyAlreadyCreated = new Error
            {
                Code = "E1",
                Message = "Impossibile creare più di una lobby"
            };
            public static readonly Error LobbyNameInUse = new Error
            {
                Code = "E2",
                Message = "Nome lobby già utilizzato"
            };
            public static readonly Error LobbyNameNotFound = new Error
            {
                Code = "E3",
                Message = "Nessuna lobby possiede il nome specificato"
            };
            public static readonly Error LobbyNameNotValid = new Error
            {
                Code = "E4",
                Message = "Nome lobby non valido"
            };
            public static readonly Error LobbyCreatorRequired = new Error
            {
                Code = "E5",
                Message = "Operazione non permessa, solo il creatore della lobby è abilitato a compierla"
            };
            public static readonly Error LobbyNotAvailable = new Error
            {
                Code = "E6",
                Message = "Lobby già occupata"
            };
            public static readonly Error NotPartecipant = new Error
            {
                Code = "E7",
                Message = "Non fai parte di questa lobby"
            };
        }
    }
}
