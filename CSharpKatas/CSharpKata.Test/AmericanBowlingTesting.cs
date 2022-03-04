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
        [TestMethod]
        public void Calculate_EmptyGame_ReturnsZero()
        {
            Game emptyGame = new Game();

            int score = ScoreCalculator.Calculate(emptyGame);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Calculate_ZeroPinsGame_ReturnsZero()
        {
            Game zeroPinsGame = new Game();

            for (int i = 0; i < 10; i++)
            {
                zeroPinsGame.Frames.Add(new Frame().WithPins(0));
            }

            int score = ScoreCalculator.Calculate(zeroPinsGame);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Calculate_OnePinEachFrameGame_ReturnsZero()
        {
            Game game = new Game();

            for (int i = 0; i < 10; i++)
            {
                game.Frames.Add(new Frame().WithPins(1));
            }

            int score = ScoreCalculator.Calculate(game);

            Assert.AreEqual(10, score);
        }
    }
}
