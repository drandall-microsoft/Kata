using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.AmericanBowling
{
    public class ScoreCalculator
    {
        public static int Calculate(Game game)
        {
            int score = 0;
            PieceMultiplierCollection pieceMultipliers = new PieceMultiplierCollection(game.CountFramePieces());

            int currentFramePiece = 0;
            foreach (var frame in game.Frames)
            {
                bool specialFrame = frame.FramePieces.Count == 3;

                foreach (var piece in frame.FramePieces)
                {
                    score += pieceMultipliers[currentFramePiece] * (int)piece.Pins;
                    if (!specialFrame)
                    {
                        pieceMultipliers.AddFramePiece(piece, currentFramePiece);
                    }
                    currentFramePiece++;
                }
            }

            return score;
        }

        private class PieceMultiplierCollection
        {
            private readonly List<int> multipliers = new List<int>();

            public PieceMultiplierCollection(int pieceCount)
            {
                multipliers.Fill(pieceCount, 1);
                this.Count = pieceCount;
            }

            public int this[int index] 
            {
                get
                {
                    return multipliers[index];
                }
                set
                {
                    multipliers[index] = value;
                }
            }

            public int Count { get; }

            public void AddFramePiece(FramePiece fp, int index)
            {
                if(fp is Strike)
                {
                    this[index + 1]++;
                    this[index + 2]++;
                }
                else if(fp is Spare)
                {
                    this[index + 1]++;
                }
            }
        }
    }
}
