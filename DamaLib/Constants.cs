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
        }
    }
}
