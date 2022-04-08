using System;
using System.Collections.Generic;
using System.Text;


namespace CSharpKatas.Rubiks
{
    using static RubiksCube;
    using static RubiksCube.Direction;
    public static class SideMapping
    {
        public static readonly Dictionary<Direction, List<int[]>> Sides = new Dictionary<Direction, List<int[]>>
        {
            {
                Front, new List<int[]>
                {
                    new int[] {0, 0, 0},
                    new int[] {1, 0, 0},
                    new int[] {2, 0, 0},
                    new int[] {0, 1, 0},
                    new int[] {1, 1, 0},
                    new int[] {2, 1, 0},
                    new int[] {0, 2, 0},
                    new int[] {1, 2, 0},
                    new int[] {2, 2, 0}
                }
            },
            {
                Back, new List<int[]>
                {
                    new int[] {0, 0, 2},
                    new int[] {1, 0, 2},
                    new int[] {2, 0, 2},
                    new int[] {0, 1, 2},
                    new int[] {1, 1, 2},
                    new int[] {2, 1, 2},
                    new int[] {0, 2, 2},
                    new int[] {1, 2, 2},
                    new int[] {2, 2, 2}
                }
            },
            {
                Left, new List<int[]>
                {
                    new int[] {0, 0, 0},
                    new int[] {0, 0, 1},
                    new int[] {0, 0, 2},
                    new int[] {0, 1, 0},
                    new int[] {0, 1, 1},
                    new int[] {0, 1, 2},
                    new int[] {0, 2, 0},
                    new int[] {0, 2, 1},
                    new int[] {0, 2, 2},

                }
            },
            {
                Right, new List<int[]>
                {
                    new int[] {2, 0, 0},
                    new int[] {2, 0, 1},
                    new int[] {2, 0, 2},
                    new int[] {2, 1, 0},
                    new int[] {2, 1, 1},
                    new int[] {2, 1, 2},
                    new int[] {2, 2, 0},
                    new int[] {2, 2, 1},
                    new int[] {2, 2, 2},
                }
            },
            {
                Down, new List<int[]>
                {
                    new int[] {0, 0, 0},
                    new int[] {0, 0, 1},
                    new int[] {0, 0, 2},
                    new int[] {1, 0, 0},
                    new int[] {1, 0, 1},
                    new int[] {1, 0, 2},
                    new int[] {2, 0, 0},
                    new int[] {2, 0, 1},
                    new int[] {2, 0, 2},
                }
            },
            {
                Up, new List<int[]>
                {
                    new int[] {0, 2, 0},
                    new int[] {0, 2, 1},
                    new int[] {0, 2, 2},
                    new int[] {1, 2, 0},
                    new int[] {1, 2, 1},
                    new int[] {1, 2, 2},
                    new int[] {2, 2, 0},
                    new int[] {2, 2, 1},
                    new int[] {2, 2, 2},
                }
            }
        };

    }
}
