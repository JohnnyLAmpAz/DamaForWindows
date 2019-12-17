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
            occupati = new BitMatrix(8, 8);
            bianchi = new BitMatrix(8, 8);
            neri = new BitMatrix(8, 8);
            pedine = new BitMatrix(8, 8);
            dame = new BitMatrix(8, 8);

            // Posizione le pedine per l'inizio della partita
            SetupMatch();
        }

        private void SetupMatch()
        {
            // Neri
            for (int pos = 1; pos <= 12; pos++)
            {
                Posizioni.Coordinate coord = Posizioni.IndexesFromPos(pos);
                occupati[coord.X, coord.Y] = true;
                neri[coord.X, coord.Y] = true;
                pedine[coord.X, coord.Y] = true;
            }

            // Bianchi
            for (int pos = 21; pos <= 32; pos++)
            {
                Posizioni.Coordinate coord = Posizioni.IndexesFromPos(pos);
                occupati[coord.X, coord.Y] = true;
                bianchi[coord.X, coord.Y] = true;
                pedine[coord.X, coord.Y] = true;
            }
        }
    }
}
