using System;

namespace DamaLib.Models.Core
{
    public static class Posizioni
    {
        public static int PosFromIndexes(int x, int y) => PosFromCoord(new Coordinate(x, y));
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
            if (pos < 1 || pos > 32)
                throw new Exception("Posizione non valida");

            // Riga
            int y = (pos - 1) / 4;

            // Colonna
            int tempX = ((pos - 1) % 4) * 2;
            int x = y % 2 == 1 ? tempX + 1 : tempX;

            return new Coordinate(x,y);
        }
    }
}