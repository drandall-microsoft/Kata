using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpKatas.Rubiks
{
    using static RubiksCube.Direction;
    using static RubiksCube.Color;
    using Direction = RubiksCube.Direction;
    using Color = RubiksCube.Color;

    public class Cubie
    {
        private static readonly int[] UpClockwise = { (int)Left, (int)Front, (int)Right, (int)Back };
        private static readonly int[] DownClockwise = Enumerable.Reverse(UpClockwise).ToArray();
        private static readonly int[] LeftClockwise = { (int)Up, (int)Front, (int)Down, (int)Back };
        private static readonly int[] RightClockwise = Enumerable.Reverse(LeftClockwise).ToArray();
        private static readonly int[] FrontClockwise = { (int)Left, (int)Up, (int)Right, (int)Down};
        private static readonly int[] BackClockwise = Enumerable.Reverse(FrontClockwise).ToArray();

        private Color[] colors = new Color[6];

        public Cubie(params (Direction, Color)[] colors)
        {
            foreach (var kvp in colors)
            {
                this.colors[(int)kvp.Item1] = kvp.Item2;
            }
        }

        public void Rotate(Direction center, bool clockwise)
        {
            if (center == Up)
            {
                if (clockwise)
                {
                    CycleSides(UpClockwise);
                }
                else
                {
                    CycleSides(DownClockwise);
                }
            }
            else if (center == Down)
            {
                if (clockwise)
                {
                    CycleSides(DownClockwise);
                }
                else
                {
                    CycleSides(UpClockwise);
                }
            }

            if (center == Left)
            {
                if (clockwise)
                {
                    CycleSides(LeftClockwise);
                }
                else
                {
                    CycleSides(RightClockwise);
                }
            }
            else if (center == Right)
            {
                if (clockwise)
                {
                    CycleSides(RightClockwise);
                }
                else
                {
                    CycleSides(LeftClockwise);
                }
            }

            if (center == Back)
            {
                if (clockwise)
                {
                    CycleSides(BackClockwise);
                }
                else
                {
                    CycleSides(FrontClockwise);
                }
            }
            else if (center == Front)
            {
                if (clockwise)
                {
                    CycleSides(FrontClockwise);
                }
                else
                {
                    CycleSides(BackClockwise);
                }
            }
        }

        public string Print(Direction side)
        {
            return colors[(int)side].ToString();
        }

        private void CycleSides(int[] indexes)
        {
            var temp = colors[indexes[0]];
            for(int i = 0; i < indexes.Length - 1; i++)
            {
                colors[indexes[i]] = colors[indexes[i + 1]];
            }
            colors[indexes[indexes.Length - 1]] = temp;
        }

        public override bool Equals(object obj)
        {
            if(obj is Cubie cubie)
            {
                for(int i = 0; i < colors.Length; i++)
                {
                    if (colors[i] != cubie.colors[i]) return false;
                }
                return true;
            }
            return false;
        }
    }

    public class CubieBuilder
    {
        private IDictionary<Direction, Color> colors = new Dictionary<Direction, Color>();

        public CubieBuilder(params (Direction, Color)[] colorMap)
        {
            foreach (var kvp in colorMap)
            {
                colors[kvp.Item1] = kvp.Item2;
            }
        }

        public Cubie Build(params Direction[] directions)
        {
            List<(Direction, Color)> pairs = new List<(Direction, Color)>();
            foreach (var dir in directions)
            {
                pairs.Add((dir, colors[dir]));
            }

            return new Cubie(pairs.ToArray());
        }
    }
}
