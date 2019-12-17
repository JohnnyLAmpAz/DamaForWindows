using System;

namespace DamaLib.Models.Core
{
    public static class Posizioni
    {
        public struct Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public static int PosFromIndexes(int x, int y)
        {
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
                throw new Exception("Indice/i non valido/i");

            int X = y % 2 == 1 ? x - 1 : x;
            X /= 2;
            int Y = y * 4 + 1;

            return Y + X;
        }
        public static Coordinate IndexesFromPos(int pos)
        {
            if (pos < 1 || pos > 32)
                throw new Exception("Posizione non valida");

            // Riga
            int y = (pos - 1) / 4;

            // Colonna
            int tempX = ((pos - 1) % 4) * 2;
            int x = y % 2 == 1 ? tempX + 1 : tempX;

            return new Coordinate() { X = x, Y = y };
        }
    }
}