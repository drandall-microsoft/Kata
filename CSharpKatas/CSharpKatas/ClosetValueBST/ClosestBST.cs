using CSharpKatas.ClosetValueBST;
using System;
using System.Collections.Generic;
using System.Text;

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
            if(tree.Root.Value == target)
            {
                return tree.Root.Value;
            }
            return NotFound;
        }
    }
}
