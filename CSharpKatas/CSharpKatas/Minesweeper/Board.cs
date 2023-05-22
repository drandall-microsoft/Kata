using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.Minesweeper
{
    public class Board
    {
        public Board(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        public uint Width { get; }
        public uint Height { get; }
        private HashSet<Tuple<long, long>> Mines = new HashSet<Tuple<long, long>>();

        public void AddMine(uint x, uint y)
        {
            Mines.Add(Tuple.Create<long, long>(x, y));
        }

        public Cell GetCell(uint x, uint y)
        {
            if (Mines.Contains(Tuple.Create<long, long>(x, y))) return new Cell(true, 999);

            uint mineCount = 0;
            for(int dX = -1; dX <= 1; dX++)
            {
                for(int dY = -1; dY <= 1; dY++)
                {
                    var newPos = Tuple.Create(x + dX, y + dY);
                    if (Mines.Contains(newPos)) mineCount++;
                }
            }
            return new Cell(false, mineCount);
        }
    }
}
