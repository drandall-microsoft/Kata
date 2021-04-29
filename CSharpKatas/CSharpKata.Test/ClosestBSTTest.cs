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

        [TestMethod]
        public void FindClosest_WithEmptyTree_ReturnsSentinalValue()
        {
            BinarySearchTree tree = new BinarySearchTree();

            ClosestBST search = new ClosestBST(tree);
            Assert.AreEqual(ClosestBST.NotFound, search.FindClosest(0));
        }

        [TestMethod]
        public void FindClosest_WithRootEqualToTarget_ReturnsRootValue()
        {
            BinarySearchTree tree = new BinarySearchTree(10);

            ClosestBST search = new ClosestBST(tree);
            Assert.AreEqual(10, search.FindClosest(10));
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
