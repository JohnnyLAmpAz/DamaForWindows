using System;
using System.Collections.Generic;
using System.Text;
using DamaLib.Models.Core;

namespace DamaLib.Models
{
    class Mossa
    {
        private List<Coordinate> salti;

        public bool Turno { get; set; }
        public List<Coordinate> Salti
        {
            get { return salti; }
            set
            {
                if (value.Count < 2)
                    throw new SaltiNonValidiException("I salti sono troppo pochi, almeno 2 richiesti (inizio e fine)");
                salti = value;
            }
        }
        public Coordinate From
        {
            get { return Salti[0]; }
            set { Salti[0] = value; }
        }
        public Coordinate To
        {
            get { return Salti[Salti.Count-1]; }
            set { Salti[Salti.Count - 1] = value; }
        }
        public List<Coordinate> Mangiati { get; set; }

        // TODO: is this good?
        //public Mossa(Scacchiera s, Coordinate from, Coordinate to)
        //{
        //    // Controllo se le celle sono valide
        //    if (!from.IsValid() || !to.IsValid())
        //        throw new CoordNotValidException();

        //    // Controllo se esiste una pedina in quella posizione e se rispecchia il giocatore indicato
        //    if (!s.Occupati[from] || !(s.Turno ? s.Bianchi[from] : s.Neri[from]))
        //        throw new PedinaNonValidaException("La pedina iniziale indicata non esiste o non appartiene al giocatore");

        //    Turno = s.Turno;

        //    // Controllo che to sia libera
        //    if (s.Occupati[to])
        //        throw new SaltiNonValidiException("La cella di destinazione non è libera!");

        //    // Controllo che from e to siano adiacenti
        //    if (s.GetNearEmptyCells(from,s.Dame[from]).Contains(to))
        //    {
        //        Salti = new List<Coordinate>() { from, to };
        //        Mangiati = new List<Coordinate>();
        //    } 
            
        //    // o se to sia nei salti possibili da from
        //    else if()
        //    {
                
        //    }
        //}

        [Serializable]
        public class SaltiNonValidiException : Exception
        {
            public SaltiNonValidiException() { }
            public SaltiNonValidiException(string message) : base(message) { }
            public SaltiNonValidiException(string message, Exception inner) : base(message, inner) { }
            protected SaltiNonValidiException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        [Serializable]
        public class PedinaNonValidaException : Exception
        {
            public PedinaNonValidaException() { }
            public PedinaNonValidaException(string message) : base(message) { }
            public PedinaNonValidaException(string message, Exception inner) : base(message, inner) { }
            protected PedinaNonValidaException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        [Serializable]
        public class CoordNotValidException : Exception
        {
            public CoordNotValidException() { }
            public CoordNotValidException(string message) : base(message) { }
            public CoordNotValidException(string message, Exception inner) : base(message, inner) { }
            protected CoordNotValidException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
