using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.ClosetValueBST
{
    public class Node
    {
        public Node Left { get; }
        public Node Right { get; }
        public int Value { get; }

        public Node(int value, Node left = null, Node right = null)
        {
            Left = left;
            Right = right;
            Value = value;
        }
    }
}
