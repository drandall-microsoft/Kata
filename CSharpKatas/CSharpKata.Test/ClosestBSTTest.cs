using CSharpKatas.ClosestValueBST;
using CSharpKatas.ClosetValueBST;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKata.Test
{
    [TestClass]
    public class ClosestBSTTest
    {
        /*
                     10
                5        15
              2   5   13     22
            1            14

        */
        private ClosestBST search;
        [TestInitialize]
        public void Setup()
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2, n1);
            Node n5_2 = new Node(5);
            Node n5 = new Node(5, n2, n5_2);
            Node n14 = new Node(14);
            Node n13 = new Node(13, null, n14);
            Node n22 = new Node(22);
            Node n15 = new Node(15, n13, n22);
            Node n10 = new Node(10, n5, n15);

            BinarySearchTree bst = new BinarySearchTree(n10);
            search = new ClosestBST(bst);
        }

        [TestMethod]
        public void FindClosest_WithNullTree_ReturnsSentinalValue()
        {
            ClosestBST search = new ClosestBST(null);

            Assert.AreEqual(ClosestBST.NotFound, search.FindClosest(0));
        }

        [TestMethod]
        public void FindClosest_WithEmptyTree_ReturnsSentinalValue()
        {
            BinarySearchTree tree = new BinarySearchTree(null);

            ClosestBST search = new ClosestBST(tree);
            Assert.AreEqual(ClosestBST.NotFound, search.FindClosest(0));
        }

        [TestMethod]
        public void FindClosest_WithRootEqualToTarget_ReturnsRootValue()
        {
            Assert.AreEqual(10, search.FindClosest(10));
        }

        [TestMethod]
        public void FindClosest_WithLeftNodeEqualToTarget_ReturnsLeftNodeValue()
        {
            Assert.AreEqual(5, search.FindClosest(5));
        }

        [TestMethod]
        public void FindClosest_WithRightNodeEqualToTarget_ReturnsRightNodeValue()
        {
            Assert.AreEqual(15, search.FindClosest(15));
        }

        [TestMethod]
        public void FindClosest_WithNonMatchingTarget_ReturnsClosestValue()
        {
            Assert.AreEqual(13, search.FindClosest(12));
        }
    }
}
