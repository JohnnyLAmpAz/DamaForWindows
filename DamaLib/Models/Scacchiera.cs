using System;
using System.Collections;
using System.Collections.Generic;
using DamaLib.Models.Core;

namespace DamaLib.Models
{
    public class Scacchiera
    {
        BitMatrix occupati, bianchi, neri, pedine, dame;
        public BitMatrix Occupati { get => occupati; private set => occupati = value; }
        public BitMatrix Bianchi { get => bianchi; private set => bianchi = value; }
        public BitMatrix Neri { get => neri; private set => neri = value; }
        public BitMatrix Pedine { get => pedine; private set => pedine = value; }
        public BitMatrix Dame { get => dame; private set => dame = value; }

        /// <summary>
        /// Tiene traccia di chi possiede il turno di gioco.
        /// false: tocca al nero. true: tocca al bianco.
        /// </summary>
        public bool Turno { get; private set; }

        public Scacchiera()
        {
            Occupati = new BitMatrix(8, 8);
            Bianchi = new BitMatrix(8, 8);
            Neri = new BitMatrix(8, 8);
            Pedine = new BitMatrix(8, 8);
            Dame = new BitMatrix(8, 8);

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
                Coordinate coord = Posizioni.CoordFromPos(pos);
                Occupati[coord] = true;
                Neri[coord] = true;
                Pedine[coord] = true;
            }

            // Bianchi
            for (int pos = 21; pos <= 32; pos++)
            {
                Coordinate coord = Posizioni.CoordFromPos(pos);
                Occupati[coord] = true;
                Bianchi[coord] = true;
                Pedine[coord] = true;
            }
        }

        public List<Coordinate> GetMoovablePieces()
        {
            List<Coordinate> moovables = new List<Coordinate>();

            List<Coordinate> pezziGiocatore = GetPlayerPieces(Turno);
            foreach (var pezzo in pezziGiocatore)
            {
                List<Coordinate> nearCells = GetNearEmptyCells(pezzo);
                if (!Dame[pezzo])
                {
                    for (int i = 0; i < nearCells.Count; i++)
                    {
                        if (nearCells[i].Y > pezzo.Y == Turno)
                        {
                            nearCells.RemoveAt(i);
                            i--;
                        }
                    }
                }

                if (nearCells.Count > 0)
                    moovables.Add(pezzo);
            }

            return moovables;
        }

        /// <summary>
        /// Determina se un pezzo si possa muovere o meno
        /// </summary>
        /// <param name="pos">Posizione del pezzo di cui si vuol sapere la possibilità di muoversi</param>
        /// <returns>TRUE: si può muovere; FALSE: NON si può muovere</returns>
        public bool IsMoovablePiece(int pos)
        {
            // Controllo che ci sia un pezzo in quella posizione
            if (IsEmptyCell(pos))
                throw new Exception($"Nessun pezzo occupa la cella numero {pos}");

            if (GetNearEmptyCells(Posizioni.CoordFromPos(pos)).Count == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Trova le celle adiacenti valide (nere, in diagonale)
        /// </summary>
        /// <param name="pos">Numero della cella di cui si vuole ottenere quelle adiacenti</param>
        /// <returns>Lista delle celle adiacenti</returns>
        public List<Coordinate> GetNearCells(Coordinate pos)
        {
            List<Coordinate> ls = new List<Coordinate>();
            for (int i = 0; i < 4; i++)
            {
                Coordinate nearC = new Coordinate(pos);

                if (i % 3 != 0)
                    nearC.X = pos.X + 1;
                else
                    nearC.X = pos.X - 1;

                if (i > 1)
                    nearC.Y = pos.Y + 1;
                else
                    nearC.Y = pos.Y - 1;

                if (nearC.IsValid())
                    ls.Add(nearC);
            }
            return ls;
        }

        /// <summary>
        /// Trova le celle adiacenti valide libere (nere, in diagonale, non occupate) 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public List<Coordinate> GetNearEmptyCells(Coordinate pos)
        {
            List<Coordinate> ls = GetNearCells(pos);
            int i = 0;
            while (i < ls.Count)
            {
                if (Occupati[ls[i]])
                    ls.Remove(ls[i]);
                else
                    i++;
            }
            return ls;
        }

        /// <summary>
        /// Indica se una cella è vuota
        /// </summary>
        /// <param name="pos">Numero della cella</param>
        /// <returns></returns>
        public bool IsEmptyCell(int pos) => !Occupati[Posizioni.CoordFromPos(pos)];

        /// <summary>
        /// Restituisce la lista delle celle occupate dai pezzi di un determinato giocatore
        /// </summary>
        /// <param name="player">Colore del giocatore. false: nero, true: bianco</param>
        /// <returns></returns>
        public List<Coordinate> GetPlayerPieces(bool player)
        {
            List<Coordinate> ls = new List<Coordinate>();

            BitMatrix pezzi;
            if (player)
                pezzi = Bianchi;
            else
                pezzi = Neri;

            List<Coordinate> occupate = GetOccupiedCells();
            foreach (var c in occupate)
                if (pezzi[c])
                    ls.Add(c);

            return ls;
        }

        /// <summary>
        /// Restituisce la lista delle celle occupate
        /// </summary>
        public List<Coordinate> GetOccupiedCells()
        {
            List<Coordinate> ls = new List<Coordinate>();

            for (int i = 0; i < 64; i++)
                if (Occupati[i])
                    ls.Add(new Coordinate(i));

            return ls;
        }
    }
}
