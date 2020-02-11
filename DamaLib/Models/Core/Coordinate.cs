using System;
using System.Collections.Generic;

namespace DamaLib.Models.Core
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinate(int pos) : this(Posizioni.CoordFromPos(pos)) { }
        public Coordinate(Coordinate copia)
        {
            X = copia.X;
            Y = copia.Y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public int Pos => Posizioni.PosFromCoord(this);

        public Coordinate GetBetweenMeAnd(Coordinate nearJump)
        {
            var dX = X - nearJump.X;
            var dY = Y - nearJump.Y;

            if (!nearJump.IsValid() || Math.Abs(dX) != 2 || Math.Abs(dY) != 2)
                throw new Exception("Invalid coords");

            return new Coordinate(dX < 0 ? X + 1 : X - 1, dY < 0 ? Y + 1 : Y - 1);
        }

        public Coordinate GetLandingAfterJumping(Coordinate jumping)
        {
            var dX = X - jumping.X;
            var dY = Y - jumping.Y;

            if (!jumping.IsValid() || Math.Abs(dX) != 1 || Math.Abs(dY) != 1)
                throw new Exception("Invalid coords");

            return new Coordinate(dX < 0 ? X + 2 : X - 2, dY < 0 ? Y + 2 : Y - 2);
        }

        // TODO: indispensabile?
        private List<Coordinate> GetNearCells(Coordinate pos)
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

        public bool IsValid() => !(X < 0 || X >= 8 || Y < 0 || Y >= 8);

        public override string ToString() => $"{X};{Y}";

        public bool Equals(Coordinate other) => other.X.Equals(X) && other.Y.Equals(Y);
    }
}
