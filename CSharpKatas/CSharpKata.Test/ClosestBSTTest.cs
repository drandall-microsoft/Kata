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

        [TestMethod]
        public void BrokeTest()
        {
            Node n208 = new Node(208);
            Node n206 = new Node(206);
            Node n4500 = new Node(4500);
            Node n203 = new Node(203);
            Node n60 = new Node(60);
            Node n5_2 = new Node(5);
            Node n3 = new Node(3);
            Node n1_5 = new Node(1);

            Node neg403 = new Node(-403);
            Node neg51 = new Node(-51, neg403);

            Node n1001 = new Node(1001, null, n4500);
            Node n207 = new Node(207, n206, n208);
            Node n55000 = new Node(55000, n1001);
            Node n205 = new Node(205, null, n207);
            Node n1_4 = new Node(1, null, n1_5);
            Node n1_3 = new Node(1, null, n1_4);
            Node n57 = new Node(57, null, n60);
            Node n1_2 = new Node(1, null, n1_3);
            Node n22 = new Node(22, null, n57);
            Node n204 = new Node(204, n203, n205);
            Node n502 = new Node(502, n204, n55000);
            Node n15 = new Node(15, n5_2, n22);

            Node n1 = new Node(1, neg51, n1_2);

            Node n2 = new Node(2, n1, n3);

            Node n5 = new Node(5, n2, n15);

            Node n100 = new Node(100, n5, n502);

            BinarySearchTree tree = new BinarySearchTree(n100);

            ClosestBST search = new ClosestBST(tree);

            Assert.AreEqual(1, search.FindClosest(-1));
        }
    }
}
