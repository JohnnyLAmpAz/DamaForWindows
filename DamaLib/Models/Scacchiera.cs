using System;
using System.Collections;
using DamaLib.Models.Core;

namespace DamaLib.Models
{
    public class Scacchiera
    {
        BitMatrix bianchi, neri, occupati, pedine, dame;

        public Scacchiera()
        {
            occupati = new BitMatrix(8,8);
            bianchi = new BitMatrix(8,8);
            neri = new BitMatrix(8,8);
            pedine = new BitMatrix(8,8);
            dame = new BitMatrix(8,8);
        }
    }
}
