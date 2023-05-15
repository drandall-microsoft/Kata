using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing.Imaging;

/*

Bowling Alley
    Lanes
    Computer
    Workers
    Monitors
    Pin Setter
    Arcade Games

    Pin Sensor -> Computer(These specific 3 pins have gone down)
        Computer [ Update it's internal state ]
        Computer -> Monitor.PlayAnimation(Turkey)
        Computer -> Monitor.Update(Current Score)
        Computer -> PinSetter.ClearDownedPins()
        Computer.Wait()
    Sensor -> Computer.UpdatePins(3, 7, 10)
        

Program
    CLI -> Inputs
        "Please enter score for Frame 1 Roll 1"
        <- 4
        "Please enter score for Frame 1 Roll 2"
        <- 6
    Game
        Players
            Names
            Handicap
            Foul Line Enabled
            Update Name
            Switch Order
            Drop Player
            Add Player
        Game State
            Current Frame
            Current Roll
        Score Calculator -> IScoreCalculator
            StandardScoring
                GetFinalScore
                GetCurrentScore
            WildBillScoring
            MysteryScoring
        GameValidator
            IsGameValid(GameState)
        UI Elements
            Erase Roll
            Change Score
    APIs
        Reset Pins
        Clear Pins
        Call Bartender
        Update Monitor
        Play Cool Animation


Game
        
*/



namespace CSharpKata.Test
{
    [TestClass]
    public class BowlingScoreTests
    {

        //When_Given_Expect
        //CalculateScore_WithAllZeros_ReturnsZero
        [TestMethod]
        public void EmptyTest()
        {
            string allTenFrames = "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0";
            Assert.AreEqual(BowlingScoreCalculator.CalculateScore(allTenFrames));
        }

        public class ScoreCalculator
        {
            public void AddFrame(int lhs, int rhs) { }

            public int CalculateScore()
            {
                return 0;
            }
        }

        [TestMethod]
        public void CalculateScore_WithAllZeros_ReturnsZero()
        {
            ScoreCalculator calc = new ScoreCalculator();
            for(int i = 0; i < 10; i++)
            {
                calc.AddFrame(0, 0);
            }

            Assert.AreEqual(0, calc.CalculateScore());
        }
    }
}
