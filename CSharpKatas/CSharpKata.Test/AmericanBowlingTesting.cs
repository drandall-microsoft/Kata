using CSharpKatas.AmericanBowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKata.Test
{
    [TestClass]
    public class AmericanBowlingTesting
    {
        private Game game = new Game();

        [TestMethod]
        public void Calculate_EmptyGame_ReturnsZero()
        {
            int score = ScoreCalculator.Calculate(game);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Calculate_ZeroPinsGame_ReturnsZero()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Frames.Add(new Frame().WithPins(0));
            }

            int score = ScoreCalculator.Calculate(game);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Calculate_OnePinEachFrameGame_ReturnsZero()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Frames.Add(new Frame().WithPins(1));
            }

            int score = ScoreCalculator.Calculate(game);

            Assert.AreEqual(10, score);
        }

        [TestMethod]
        public void Calculate_StrikeThreeFour_Returns24()
        {
            game.Frames.Add(new Frame().Strike());
            game.Frames.Add(new Frame().WithPins(3).WithPins(4));

            int score = ScoreCalculator.Calculate(game);
            Assert.AreEqual(24, score);
        }

        [TestMethod]
        public void Calculate_ThreeSpareOneTwo_Returns14()
        {
            game.Frames.Add(new Frame().WithPins(3).Spare());
            game.Frames.Add(new Frame().WithPins(1).WithPins(2));

            int score = ScoreCalculator.Calculate(game);

            Assert.AreEqual(14, score);
        }

        [TestMethod]
        public void Calculate_PerfectGame_Returns300()
        {
            for(int i = 0; i < 9; i++)
            {
                game.Frames.Add(new Frame().Strike());
            }

            game.Frames.Add(new Frame().Strike().Strike().Strike());

            int score = ScoreCalculator.Calculate(game);

            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void Calculate_ThreeStrikeFrame_Returns30()
        {
            game.Frames.Add(new Frame().Strike().Strike().Strike());

            Assert.AreEqual(30, ScoreCalculator.Calculate(game));

            //X X X
            //1 2 3
            //30 + 20 + 10 = 60
            //1 1 1
            // 10 + 10 + 10

            //[3/3]
            //3 + 7 + 3 = 13
            //3 + 10 + 3 = 16

            //[XX0]
            //[X34
        }
    }
}
