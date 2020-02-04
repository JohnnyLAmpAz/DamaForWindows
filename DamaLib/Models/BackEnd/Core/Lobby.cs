using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DamaLib.Models.BackEnd.Core
{
    public class Lobby
    {
        public string Nome { get; private set; }
        public IPAddress Creatore { get; set; }
        public IPAddress Unito{ get; set; }

        public Lobby(IPAddress c, string nome)
        {
            Nome = nome;
            Creatore = c;
            Unito = default;
        }
    }
}
