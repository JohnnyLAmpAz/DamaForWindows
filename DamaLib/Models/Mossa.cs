using System;
using System.Collections.Generic;
using System.Text;
using DamaLib.Models.Core;

namespace DamaLib.Models
{
    public class Mossa : IEquatable<Mossa>
    {
        private List<Coordinate> salti;

        public Mossa(List<Coordinate> salti, List<Coordinate> mangiati)
        {
            Salti = salti ?? throw new ArgumentNullException(nameof(salti));
            Mangiati = mangiati ?? throw new ArgumentNullException(nameof(mangiati));
        }

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
        public int NumMangiati { get => Mangiati.Count; }
        public bool IsFirstDama(Scacchiera s) => s.Dame[Salti[0]];
        public int NumDameMangiate(Scacchiera s)
        {
            int n = 0;
            foreach (var mangiato in Mangiati)
                if (s.Dame[mangiato])
                    n++;
            return n;
        }
        public int IndexFirstDama(Scacchiera s)
        {
            for (int i = 0; i < Mangiati.Count; i++)
                if (s.Dame[Mangiati[i]])
                    return i;
            return -1;
        }

        public bool Equals(Mossa other) => Salti.Equals(other.Salti) && Mangiati.Equals(other.Mangiati);

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
