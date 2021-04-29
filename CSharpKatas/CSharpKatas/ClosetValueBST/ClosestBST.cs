using CSharpKatas.ClosetValueBST;

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

            Node root = tree.Root;
            Node left = root.Left;
            Node right = root.Right;

            if (root.Value > target)
            {
                return left.Value;
            }
            else if(root.Value < target)
            {
                return right.Value;
            }
            else if (root.Value == target)
            {
                return root.Value;
            }
            return NotFound;
        }

        private int Closest(Node node, int target)
        {
            if(node == null)
            {
                return int.MaxValue;
            }
            Node left = node.Left;
            Node right = node.Right;

            int leftValue = Closest(left, target);
            int rightValue = Closest(right, target);


        }
    }
}
