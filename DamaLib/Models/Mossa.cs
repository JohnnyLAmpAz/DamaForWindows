using System;
using System.Collections.Generic;
using System.Text;
using DamaLib.Models.Core;

namespace DamaLib.Models
{
    class Mossa
    {
        public bool Turno { get; set; }
        public Coordinate From { get; set; }
        public Coordinate To { get; set; }
    }
}
