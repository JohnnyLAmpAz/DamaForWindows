using System;
using System.Collections;

namespace DamaLib.Models.Core
{
    public class BitMatrix
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

        public bool this[int i]
        {
            get
            {
                if (i < 0 || i >= bitArray.Length)
                    throw new Exception("Indice non valido");
                return bitArray[i];
            }
        }
        public bool this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= Width || y < 0 || y >= Height)
                    throw new Exception("Indice/i non valido/i");
                return bitArray[GetIndexFromCoord(x, y)];
            }
            set
            {
                if (x < 0 || x >= Width || y < 0 || y >= Height)
                    throw new Exception("Indice/i non valido/i");
                bitArray[GetIndexFromCoord(x, y)] = value;
            }
        }
        public bool this[Coordinate c] { get => this[c.X, c.Y]; set => this[c.X, c.Y] = value; }


        private int GetIndexFromCoord(int x, int y) => y * (Width) + x;
    }
}