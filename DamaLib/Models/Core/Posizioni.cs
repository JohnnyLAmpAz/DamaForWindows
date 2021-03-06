using System;

namespace DamaLib.Models.Core
{
    public static class Posizioni
    {
        public static int PosFromIndexes(int x, int y) => PosFromCoord(new Coordinate(x, y));
        public static int PosFromIndex(int i)
        {
            if (i < 0 || i > 63)
                throw new Exception("Index non valido");
            return PosFromCoord(new Coordinate(i % 8, i / 8));
        }
        public static int PosFromCoord(Coordinate c)
        {
            if(!c.IsValid())
                throw new Exception("Indice/i non valido/i");

            int X = c.Y % 2 == 1 ? c.X - 1 : c.X;
            X /= 2;
            int Y = c.Y * 4 + 1;

            return Y + X;
        }
        public static Coordinate CoordFromPos(int pos)
        {
            if (!IsValid(pos))
                throw new Exception("Posizione non valida");

            // Riga
            int y = (pos - 1) / 4;

            // Colonna
            int tempX = ((pos - 1) % 4) * 2;
            int x = y % 2 == 1 ? tempX + 1 : tempX;

            return new Coordinate(x,y);
        }

        public static bool IsValid(int pos) => pos > 0 && pos < 33;
    }
}