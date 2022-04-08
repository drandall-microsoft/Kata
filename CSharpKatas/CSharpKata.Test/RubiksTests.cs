using System;
using System.Collections.Generic;
using System.Text;
using CSharpKatas.Rubiks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpKata.Test
{
    using static RubiksCube.Direction;
    using static RubiksCube.Color;

    [TestClass]
    public class RubiksTests
    {
        [TestMethod]
        public void ConstructDefaultCube()
        {
            RubiksCube cube = new RubiksCube();
        }

        [TestMethod]
        public void UpSide_OnNewCube_IsAllYellow()
        {
            var cube = new RubiksCube();
            var colorString = cube.SideToString(RubiksCube.Direction.Up);

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 9; i++)
            {
                sb.Append("Yellow ");
            }

            Assert.AreEqual(colorString, sb.ToString().Trim());
        }

        [TestMethod]
        public void Rotate_CubieOnUp_ChangesLeftFrontRightBack()
        {
            Cubie initial = new Cubie((Up, Yellow), (Down, White), (Left, Blue), (Right, Green), (Front, Red), (Back, Orange));
            Cubie expected = new Cubie((Up, Yellow), (Down, White), (Left, Red), (Right, Orange), (Front, Green), (Back, Blue));

            initial.Rotate(Up, true);

            Assert.AreEqual(initial, expected);
        }

    }
}
