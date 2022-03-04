using System.Collections.Generic;

namespace CSharpKatas.AmericanBowling
{
    //TODO: Start Here - implement Curtis Bowling
    //Positive points for first ball
    //Negative points for second ball
    //Must bowl 3 pieces on last frame
    //Third piece is also negative
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
