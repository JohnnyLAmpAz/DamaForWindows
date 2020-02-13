using DamaLib.Models.Core;
using System;
using System.Collections.Generic;

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
            SetupPedine();

            // Imposto il turno iniziale al bianco
            Turno = true;
        }

        private void SetupPedine()
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

        #region Alter pedine
        private void Remove(Coordinate c)
        {
            if (Occupati[c])
                Occupati[c] = Neri[c] = Bianchi[c] = Pedine[c] = Dame[c] = false;
            else
                throw new Exception("Nessusa pedina in questa cella");
        }
        #endregion

        // TODO: ???
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
        public List<Coordinate> GetNearCells(Coordinate pos, bool isDama = true)
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

            // Se è una pedina ritorno solo quelle nel verso giusto
            if (!isDama)
            {
                bool colore = GetColore(pos);
                var realLs = new List<Coordinate>();

                foreach (var dest in ls)
                {
                    if (dest.Y < pos.Y == colore)
                        realLs.Add(dest);
                }
                return realLs;
            }

            return ls;
        }

        public List<Coordinate> GetNearJumps(Coordinate pos, bool isDama = true)
        {
            List<Coordinate> ls = new List<Coordinate>();
            for (int i = 0; i < 4; i++)
            {
                Coordinate nearJ = new Coordinate(pos);

                if (i % 3 != 0)
                    nearJ.X = pos.X + 2;
                else
                    nearJ.X = pos.X - 2;

                if (i > 1)
                    nearJ.Y = pos.Y + 2;
                else
                    nearJ.Y = pos.Y - 2;
                nearJ.Y = pos.Y - 2;

                if (nearJ.IsValid())
                    ls.Add(nearJ);
            }

            // Se è una pedina ritorno solo quelle nel verso giusto
            if (!isDama)
            {
                bool colore = GetColore(pos);
                var realLs = new List<Coordinate>();

                foreach (var dest in ls)
                {
                    if (dest.Y < pos.Y == colore)
                        realLs.Add(dest);
                }
                return realLs;
            }
            return ls;
        }

        public List<Coordinate> GetNearEmptyJumps(Coordinate pos, bool isDama = true)
        {
            var eJ = new List<Coordinate>();
            var ls = GetNearJumps(pos, isDama);
            foreach (var j in ls)
                if (!Occupati[j])
                    eJ.Add(j);
            return eJ;
        }

        public List<Coordinate> GetNearEmptyEatingJumps(Coordinate pos, bool isDama = true)
        {
            var ls = new List<Coordinate>();
            foreach (var j in GetNearEmptyJumps(pos, isDama))
            {
                var between = pos.GetBetweenMeAnd(j);
                if (Occupati[between] && 
                    GetColore(between) != GetColore(pos) &&
                    !(!isDama && Dame[between]))
                    ls.Add(j);
            }
            return ls;
        }

        /// <summary>
        /// Trova le celle adiacenti valide libere (nere, in diagonale, non occupate) 
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public List<Coordinate> GetNearEmptyCells(Coordinate pos, bool isDama = true)
        {
            List<Coordinate> ls = GetNearCells(pos, isDama);
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
                    ls.Add(new Coordinate(Posizioni.PosFromIndex(i)));

            return ls;
        }

        public List<Coordinate> GetNearEatableEnemies(Coordinate c, bool isDama = true)
        {
            var ls = new List<Coordinate>();
            var colore = GetColore(c);
            foreach (var cell in GetNearCells(c))
                if (Occupati[cell] &&
                    colore != GetColore(cell) &&
                    !Occupati[c.GetLandingAfterJumping(cell)] &&
                    !(Pedine[c] && Dame[cell]))
                    ls.Add(cell);
            return ls;
        }

        public bool GetColore(Coordinate c)
        {
            if (Bianchi[c])
                return true;
            else if (Neri[c])
                return false;
            else
                throw new Exception("Colore non valido");
        }

        private List<Mossa> FindPossiblePlayerMooves()
        {
            var lsMosse = new List<Mossa>();

            // Ottengo lista delle pedine del giocatore che ha il turno
            var playerPeds = GetPlayerPieces(Turno);

            // Itero su tutte le pedine del giocatore
            // bool che tiene traccia se ho mosse che mangiano o meno - priorità a quelle che mangiano, scartando le altre
            bool eatingWithDama = false;
            int maxNumEating = 0, numEatingDame = 0, minIndexFirstDama = -1;
            foreach (var ped in playerPeds)
            {
                var nearEatableEnemies = GetNearEatableEnemies(ped, Dame[ped]);

                // Controllo se non si possono mangiare pedine intorno
                if (nearEatableEnemies.Count == 0)
                {
                    // Se ci sono gia altre mosse possibili che mangiano lascio perdere questa
                    if (maxNumEating > 0)
                        continue;

                    // Altrimenti cerco e aggiungo alle mosse eventuali caselle adiacenti libere in cui spostarsi
                    foreach (var emptyCell in GetNearEmptyCells(ped, Dame[ped]))
                        lsMosse.Add(new Mossa(
                            new List<Coordinate>() { ped, emptyCell },
                            new List<Coordinate>()
                        ));
                }
                // Se si possono mangiare pedine intorno
                else
                {
                    // Allora genero tutte le mosse possibili (magari non valide: priorità non controllate!)
                    var jumpingMooves = FindPossibleJumpingEatingPedMooves(ped, Dame[ped]);

                    // Switcho alla modalità eating se prima non lo ero, svuotando la lissta delle mosse
                    if (maxNumEating == 0)
                    {
                        lsMosse.Clear();
                        maxNumEating = jumpingMooves[0].NumMangiati;
                    }

                    // Le itero controllando le priorità
                    foreach (var m in jumpingMooves)
                    {
                        // MAX numero di pedine mangiate
                        if (m.NumMangiati > maxNumEating)
                        {
                            // Se questa mossa mangia piu pedine di tutte le mosse fino ad ora trovate, la rendo l'unica nuova disponibile
                            lsMosse = new List<Mossa>() { m };
                            maxNumEating = m.NumMangiati;
                            eatingWithDama = m.IsFirstDama(this);
                            numEatingDame = m.NumDameMangiate(this);
                            minIndexFirstDama = m.IndexFirstDama(this);
                        }
                        else if (m.NumMangiati == maxNumEating)
                        {
                            // TODO: Dame > Pedine

                        }
                        else
                            continue; // Se ne mangia di meno non la prendo nemmeno in considerazione
                    }
                }
            }
        }

        private List<Mossa> FindPossibleJumpingEatingPedMooves(Coordinate from, bool isDama = true) => 
            RecursiveFindJumpingEatingMooves(
                new List<Coordinate>(),from,isDama);
        private List<Mossa> RecursiveFindJumpingEatingMooves(List<Coordinate> mangiati, Coordinate from, bool isDama = true)
        {
            var lsMosse = new List<Mossa>();

            // Guardo se posso mangiare delle pedine
            var nearEatingJumps = GetNearEmptyEatingJumps(from, isDama);

            // Tolgo quelle che eventualmente sono già state mangiate in precedenza (nel caso del giro tondo con la dama, pericolo di stallo)
            for (int i = 0; i < nearEatingJumps.Count; i++)
            {
                if (mangiati.Contains(nearEatingJumps[i]))
                {
                    nearEatingJumps.RemoveAt(i);
                    i--;
                    continue;
                }
            }

            // Per ogni pedina mangiabile creo ed aggiungo la mossa
            foreach (var jump in nearEatingJumps)
            {
                // Costruisco la lista completa delle pedine mangiate in precedenza + la mia
                var allMangiati = new List<Coordinate>(mangiati);
                allMangiati.Add(from.GetBetweenMeAnd(jump));

                // Richiamo la funzione ricorsiva per poi aggiungere le mosse che mi ritorna alle mie
                foreach (var m in RecursiveFindJumpingEatingMooves(allMangiati,jump,isDama))
                {
                    var oldJumps = m.Salti;
                    var oldMangiati = m.Mangiati;
                    m.Salti = new List<Coordinate>() { new Coordinate(from) };
                    m.Mangiati = new List<Coordinate>() { from.GetBetweenMeAnd(jump) };
                    m.Salti.AddRange(oldJumps);
                    m.Mangiati.AddRange(oldMangiati);
                    lsMosse.Add(m);
                }
            }

            return lsMosse;
        }
    }
}
