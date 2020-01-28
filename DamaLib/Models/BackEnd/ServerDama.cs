using System;
using System.Collections.Generic;
using System.Text;
using DamaLib.Models.BackEnd.Core;

namespace DamaLib.Models.BackEnd
{
    class ServerDama : TcpServer
    {
        public ServerDama() : base(55555)
        {
        }

        public override string Handler(string req)
        {
            return "";
        }
    }
}
