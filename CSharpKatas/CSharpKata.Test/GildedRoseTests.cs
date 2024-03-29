﻿using CSharpKatas.GildedRose;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpKata.Test
{
    [TestClass]
    public class GildedRoseTests
    {
        private const int StartingQuality = 5;
        private const int StartingSellIn = 10;
        private const string OrdinaryItemName = "Ordinary Item";

        private Item ordinaryItem;
        private Item agedBrie;
        private Item sulfuras;
        private Item backstagePass;
        private Item conjuredItem;
        private GildedRose ordinaryRose;
        private GildedRose allItemsRose;

        [TestInitialize]
        public void SetUp()
        {
            ordinaryItem = CreateItem(OrdinaryItemName);
            agedBrie = CreateItem(GildedRose.AgedBrie);
            sulfuras = CreateItem(GildedRose.Sulfuras);
            backstagePass = CreateItem(GildedRose.BackStagePass);
            conjuredItem = CreateItem(GildedRose.Conjured);

            ordinaryRose = new GildedRose(new[] { ordinaryItem });
            allItemsRose = new GildedRose(new[] { ordinaryItem, agedBrie, sulfuras, backstagePass });
        }

        [TestMethod]
        public void GivenAnOrdinaryItem_AfterUpdate_QualityDecreasesByOne()
        {
            ordinaryRose.UpdateQuality();
            Assert.AreEqual(StartingQuality - 1, ordinaryItem.Quality);
        }

        [TestMethod]
        public void GivenAnOrdinaryItem_AfterUpdate_SellInDecreasesByOne()
        {
            ordinaryRose.UpdateQuality();
            Assert.AreEqual(StartingSellIn - 1, ordinaryItem.SellIn);
        }

        [TestMethod]
        public void GivenAnItemWithZeroQuality_AfterUpdate_QualityRemainsAtZero()
        {
            ordinaryItem.Quality = GildedRose.MinQuality;
            ordinaryRose.UpdateQuality();
            Assert.AreEqual(0, ordinaryItem.Quality);
        }

        [TestMethod]
        public void GivenAnItemWithZeroSellIn_AfterUpdate_SellInGoesNegative()
        {
            ordinaryItem.SellIn = 0;
            ordinaryRose.UpdateQuality();
            Assert.AreEqual(-1, ordinaryItem.SellIn);
        }

        [TestMethod]
        public void GivenAgedBrie_AfterUpdate_QualityIncreasesByOne()
        {
            var rose = new GildedRose(new[] { agedBrie });
            rose.UpdateQuality();

            Assert.AreEqual(StartingQuality + 1, agedBrie.Quality);
        }

        [TestMethod]
        public void GivenAgedBrie_AfterUpdate_SellInDecreasesByOne()
        {
            var rose = new GildedRose(new[] { agedBrie });
            rose.UpdateQuality();

            Assert.AreEqual(StartingSellIn - 1, agedBrie.SellIn);
        }

        [TestMethod]
        public void GivenMaxedValueAgedBrie_AfterUpdate_QualityRemainsUnchanged()
        {
            agedBrie.Quality = GildedRose.MaxQuality;
            var rose = new GildedRose(new[] { agedBrie });
            rose.UpdateQuality();

            Assert.AreEqual(GildedRose.MaxQuality, agedBrie.Quality);
        }

        [TestMethod]
        public void GivenSulfuras_AfterUpdate_QualityRemainsUnchanged()
        {
            var rose = new GildedRose(new[] { sulfuras });
            rose.UpdateQuality();

            Assert.AreEqual(StartingQuality, sulfuras.Quality);
        }

        [TestMethod]
        public void GivenSulfuras_AfterUpdate_SellInRemainsUnchanged()
        {
            var rose = new GildedRose(new[] { sulfuras });
            rose.UpdateQuality();

            Assert.AreEqual(StartingSellIn, sulfuras.SellIn);
        }

        [TestMethod]
        public void GivenBackstagePassWithMoreThanTenDaysLeft_AfterUpdate_QualityIncreasesByOne()
        {
            backstagePass.SellIn = 20;
            var rose = new GildedRose(new[] { backstagePass });
            rose.UpdateQuality();

            Assert.AreEqual(StartingQuality + 1, backstagePass.Quality);
        }

        [TestMethod]
        public void GivenBackstagePassWithTenDaysLeft_AfterUpdate_QualityIncreasesByTwo()
        {
            backstagePass.SellIn = 10;
            var rose = new GildedRose(new[] { backstagePass });
            rose.UpdateQuality();

            Assert.AreEqual(StartingQuality + 2, backstagePass.Quality);
        }

        [TestMethod]
        public void GivenBackstagePassWithFiveDaysLeft_AfterUpdate_QualityIncreasesByThree()
        {
            backstagePass.SellIn = 5;
            var rose = new GildedRose(new[] { backstagePass });
            rose.UpdateQuality();

            Assert.AreEqual(StartingQuality + 3, backstagePass.Quality);
        }

        [TestMethod]
        public void GivenBackstagePassWithZeroDaysLeft_AfterUpdate_QualityIsSetToZero()
        {
            backstagePass.SellIn = 0;
            var rose = new GildedRose(new[] { backstagePass });
            rose.UpdateQuality();

            Assert.AreEqual(0, backstagePass.Quality);
        }

        [TestMethod]
        public void GivenConjuredItem_AfterUpdate_QualityIsReducedByTwo()
        {
            var rose = new GildedRose(new[] { conjuredItem });
            rose.UpdateQuality();

            Assert.AreEqual(StartingQuality - 2, conjuredItem.Quality);
        }


        [TestMethod]
        public void GivenAllItems_AfterUpdate_QualityAndSellInChangeAppropriately()
        {
            backstagePass.SellIn = 25;

            allItemsRose.UpdateQuality();

            Assert.AreEqual(StartingSellIn - 1, ordinaryItem.SellIn);
            Assert.AreEqual(StartingQuality - 1, ordinaryItem.Quality);

            Assert.AreEqual(StartingSellIn - 1, agedBrie.SellIn);
            Assert.AreEqual(StartingQuality + 1, agedBrie.Quality);

            Assert.AreEqual(StartingSellIn, sulfuras.SellIn);
            Assert.AreEqual(StartingQuality, sulfuras.Quality);

            Assert.AreEqual(24, backstagePass.SellIn);
            Assert.AreEqual(StartingQuality + 1, backstagePass.Quality);
        }

        private Item CreateItem(string name)
        {
            return new Item
            {
                Name = name,
                Quality = StartingQuality,
                SellIn = StartingSellIn
            };
        }
    }
}
