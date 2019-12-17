using System;
using System.Collections;

namespace DamaLib.Models.Core
{
    class BitMatrix
    {
        BitArray bitArray;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public BitMatrix(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            bitArray = new BitArray(width * height);
        }

        public bool this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= Width || y < 0 || y >= Height)
                    throw new Exception("Indice/i non valido/i");
                return bitArray[y*(Width)+x];
            }
            private set
            {
                if (x < 0 || x >= Width || y < 0 || y >= Height)
                    throw new Exception("Indice/i non valido/i");
                bitArray[y*(Width)+x] = value;
            }
        }
    }
}