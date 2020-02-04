using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DamaLib.Models.BackEnd.Core
{
    public class Lobby
    {
        public string Nome { get; private set; }
        public string Creatore { get; set; }
        public string Unito{ get; set; }

        public Lobby(string c, string nome)
        {
            Nome = nome;
            Creatore = c;
            Unito = default;
        }
    }
}
