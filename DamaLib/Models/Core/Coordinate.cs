using System;
using System.Collections.Generic;
using System.Text;

namespace DamaLib.Models.Core
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinate(int pos) => Posizioni.CoordFromPos(pos);
        public Coordinate(Coordinate copia)
        {
            X = copia.X;
            Y = copia.Y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public int GetPos() => Posizioni.PosFromCoord(this);
        public bool IsValid() => !(X < 0 || X >= 8 || Y < 0 || Y >= 8);

        public bool Equals(Coordinate other) => other.X.Equals(X) && other.Y.Equals(Y);
    }
}
