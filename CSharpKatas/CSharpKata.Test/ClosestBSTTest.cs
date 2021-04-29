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
            /*
             {"id": "10", "left": "5", "right": "15", "value": 10},
      {"id": "15", "left": "13", "right": "22", "value": 15},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "13", "left": null, "right": "14", "value": 13},
      {"id": "14", "left": null, "right": null, "value": 14},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1}
            */
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
            BinarySearchTree tree = new BinarySearchTree(new Node(10));

            ClosestBST search = new ClosestBST(tree);
            Assert.AreEqual(10, search.FindClosest(10));
        }

        [TestMethod]
        public void FindClosest_WithLeftNodeEqualToTarget_ReturnsLeftNodeValue()
        {
            Node leftNode = new Node(5);
            BinarySearchTree tree = new BinarySearchTree(new Node(10, leftNode));

            ClosestBST search = new ClosestBST(tree);
            Assert.AreEqual(5, search.FindClosest(5));
        }
    }
}
/*
 * {
  "tree": {
    "nodes": [
      {"id": "10", "left": "5", "right": "15", "value": 10},
      {"id": "15", "left": "13", "right": "22", "value": 15},
      {"id": "22", "left": null, "right": null, "value": 22},
      {"id": "13", "left": null, "right": "14", "value": 13},
      {"id": "14", "left": null, "right": null, "value": 14},
      {"id": "5", "left": "2", "right": "5-2", "value": 5},
      {"id": "5-2", "left": null, "right": null, "value": 5},
      {"id": "2", "left": "1", "right": null, "value": 2},
      {"id": "1", "left": null, "right": null, "value": 1}
    ],
    "root": "10"
  },
  "target": 12
}
*/
