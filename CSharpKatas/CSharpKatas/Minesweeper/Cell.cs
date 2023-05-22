using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.Minesweeper
{
    public class Cell
    {
        public Cell(bool isMine, uint value)
        {
            IsMine = isMine;
            Value = value;
        }

        public bool IsMine { get; }
        public uint Value { get; }
    }
}
