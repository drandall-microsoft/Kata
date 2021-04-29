﻿using CSharpKatas.ClosetValueBST;
using System;

namespace CSharpKatas.ClosestValueBST
{
    public class ClosestBST
    {
        public const int NotFound = -1;
        private readonly BinarySearchTree tree;

        public ClosestBST(BinarySearchTree tree)
        {
            this.tree = tree;
        }

        public int FindClosest(int target)
        {
            if (tree?.Root == null)
            {
                return NotFound;
            }

            return Closest(tree.Root, target);
        }

        private int Closest(Node node, int target)
        {
            if (node == null)
            {
                return int.MaxValue;
            }

            Node left = node.Left;
            Node right = node.Right;

            int leftValue = Closest(left, target);
            int rightValue = Closest(right, target);
            int currentValue = Math.Abs(target - node.Value);

            if (Math.Abs(target - leftValue) < currentValue)
            {
                return leftValue;
            }
            else if (Math.Abs(target - rightValue) < currentValue)
            {
                return rightValue;
            }
            else
            {
                return node.Value;
            }
        }
    }
}
