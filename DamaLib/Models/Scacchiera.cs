using System;
using System.Collections;
using DamaLib.Models.Core;

namespace DamaLib.Models
{
    public class Scacchiera
    {
        BitMatrix bianchi, neri, occupati, pedine, dame;

        /// <summary>
        /// Tiene traccia di chi possiede il turno di gioco
        /// false: tocca al nero. true: tocca al bianco.
        /// </summary>
        public bool Turno { get; private set; }

        public Scacchiera()
        {
            occupati = new BitMatrix(8, 8);
            bianchi = new BitMatrix(8, 8);
            neri = new BitMatrix(8, 8);
            pedine = new BitMatrix(8, 8);
            dame = new BitMatrix(8, 8);

            // Posizione le pedine per l'inizio della partita
            SetupMatch();

            // Imposto il turno iniziale al bianco
            Turno = true;
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
