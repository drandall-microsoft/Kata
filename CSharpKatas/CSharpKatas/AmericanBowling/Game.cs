using System.Collections.Generic;

namespace CSharpKatas.AmericanBowling
{
    public class Game
    {
        public List<Frame> Frames { get; } = new List<Frame>();

        public int CountFramePieces()
        {
            int total = 0;
            foreach(var f in Frames)
            {
                total += f.FramePieces.Count;
            }

            return total;
        }
    }
}
