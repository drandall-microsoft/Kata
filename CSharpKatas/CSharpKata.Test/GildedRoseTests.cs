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

            ordinaryRose = new GildedRose(new[] { ordinaryItem });
        }

        [TestMethod]
        public void GivenAnOrdinaryItem_AfterUpdate_QualityDecreasesByOne()
        {

            ordinaryRose.UpdateQuality();

            Assert.AreEqual(StartingQuality-1, ordinaryItem.Quality);
        }

        [TestMethod]
        public void GivenAnOrdinaryItem_AfterUpdate_SellInDecreasesByOne()
        {

            ordinaryRose.UpdateQuality();

            Assert.AreEqual(StartingSellIn-1, ordinaryItem.SellIn);
        }
    }
}
