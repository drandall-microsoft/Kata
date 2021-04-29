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

            if (tree.Root.Value > target)
            {
                return tree.Root.Left.Value;
            }
            else if (tree.Root.Value == target)
            {
                return tree.Root.Value;
            }
            return NotFound;
        }
    }
}
