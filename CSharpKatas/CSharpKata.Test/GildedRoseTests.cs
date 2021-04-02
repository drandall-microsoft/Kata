using CSharpKatas;
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
        private GildedRose ordinaryRose;

        [TestInitialize]
        public void SetUp()
        {
            ordinaryItem = new Item
            {
                Name = OrdinaryItemName,
                Quality = StartingQuality,
                SellIn = StartingSellIn
            };

            agedBrie = new Item
            {
                Name = "Aged Brie",
                Quality = StartingQuality,
                SellIn = StartingSellIn
            };

            sulfuras = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = StartingQuality,
                SellIn = StartingSellIn
            };

            backstagePass = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = StartingQuality,
                SellIn = 20
            };

            ordinaryRose = new GildedRose(new[] { ordinaryItem });
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
            ordinaryItem.Quality = 0;
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
    }
}
