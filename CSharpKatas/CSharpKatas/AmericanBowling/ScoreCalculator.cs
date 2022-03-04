using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.AmericanBowling
{
    public class ScoreCalculator
    {
        // for each frame, for each frame piece
        // - 
        public static int Calculate(Game game)
        {
            int score = 0;
            int bonusFrames = 0;
            foreach (var frame in game.Frames)
            {
                foreach (var piece in frame.FramePieces)
                {
                    int pins = (int)piece.Pins;
                    score += pins;
                    if (bonusFrames > 0)
                    {
                        score += pins;
                        bonusFrames--;
                    }
                }
            }

            return score;
        }
    }
}
