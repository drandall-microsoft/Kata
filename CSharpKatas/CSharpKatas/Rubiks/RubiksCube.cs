using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.Rubiks
{
    using static RubiksCube.Color;
    using static RubiksCube.Direction;

    public class RubiksCube
    {
        public enum Color { Red, Orange, Green, Blue, White, Yellow, Invisible };
        public enum Direction { Up, Down, Left, Right, Back, Front };

        public const int SideLength = 3;

        private Cubie[,,] cubies = new Cubie[SideLength, SideLength, SideLength];

        public RubiksCube()
        {
            CubieBuilder builder = new CubieBuilder((Up, Yellow), (Down, White), (Front, Red), (Back, Orange), (Left, Blue), (Right, Green));

            // layer 1
            cubies[0, 0, 0] = builder.Build(Down, Front, Left);
            cubies[1, 0, 0] = builder.Build(Down, Front);
            cubies[2, 0, 0] = builder.Build(Down, Front, Right);

            cubies[0, 1, 0] = builder.Build(Front, Left);
            cubies[1, 1, 0] = builder.Build(Front);
            cubies[2, 1, 0] = builder.Build(Front, Right);

            cubies[0, 2, 0] = builder.Build(Up, Front, Left);
            cubies[1, 2, 0] = builder.Build(Up, Front);
            cubies[2, 2, 0] = builder.Build(Up, Front, Right);

            // layer 2
            cubies[0, 0, 1] = builder.Build(Down, Left);
            cubies[1, 0, 1] = builder.Build(Down);
            cubies[2, 0, 1] = builder.Build(Down, Right);

            cubies[0, 1, 1] = builder.Build(Left);
            cubies[1, 1, 1] = builder.Build();
            cubies[2, 1, 1] = builder.Build(Right);

            cubies[0, 2, 1] = builder.Build(Up, Left);
            cubies[1, 2, 1] = builder.Build(Up);
            cubies[2, 2, 1] = builder.Build(Up, Right);

            // layer 3
            cubies[0, 0, 2] = builder.Build(Down, Back, Left);
            cubies[1, 0, 2] = builder.Build(Down, Back);
            cubies[2, 0, 2] = builder.Build(Down, Back, Right);

            cubies[0, 1, 2] = builder.Build(Back, Left);
            cubies[1, 1, 2] = builder.Build(Back);
            cubies[2, 1, 2] = builder.Build(Back, Right);

            cubies[0, 2, 2] = builder.Build(Up, Back, Left);
            cubies[1, 2, 2] = builder.Build(Up, Back);
            cubies[2, 2, 2] = builder.Build(Up, Back, Right);
        }

        //Methods

        public void Rotate(Direction side, bool clockwise)
        {
            var coords = SideMapping.Sides[side];
            var cubies = GetCubies(coords);

            //4-way swap corners
            //4-way swap edges

            //foreach cubie
            //cubie.Rotate(CenterColor, clockwise)
        }

        public string SideToString(Direction direction)
        {
            var cubies = GetCubies(SideMapping.Sides[direction]);

            StringBuilder sb = new StringBuilder();
            foreach(var cubie in cubies)
            {
                sb.Append(cubie.Print(direction));
                sb.Append(" ");
            }

            return sb.ToString().Trim();
        }

        private List<Cubie> GetCubies(List<int[]> coords)
        {
            List<Cubie> result = new List<Cubie>();
            foreach (var coord in coords)
            {
                result.Add(cubies[coord[0], coord[1], coord[2]]);
            }

            return result;
        }
    }
}
