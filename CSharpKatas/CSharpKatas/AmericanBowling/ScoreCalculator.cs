using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.AmericanBowling
{
    public class ScoreCalculator
    {
        public static int Calculate(Game game)
        {

            Game testGame = new Game();
            for(int i = 0; i < 9; i++)
            {
                testGame.Frames.Add(new Frame().Strike());
            }
            testGame.Frames.Add(new Frame().Strike().Strike().Strike());

            //ASSERT_ARE_EQUAL(ScoreCalculator.Calculate(testGame), 300);
            Frame f = new Frame().WithPins(4).Spare();

            new Frame().Strike();

            new Frame().Strike().Strike().Strike();

            new Frame().Strike().WithPins(4).Spare();
            foreach(var frame in game.Frames)
            {
                foreach(var piece in frame.FramePieces)
                {
                }
            }

            return 0;
        }
    }
}
