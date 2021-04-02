using CSharpKatas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpKata.Test
{
    [TestClass]
    public class GildedRoseTests
    {
        [TestMethod]
        public void GivenAnOrdinaryItem_AfterUpdate_QualityDecreasesByOne()
        {
            var item = new Item
            {
                Name = "Ordianry Item",
                Quality = 5,
                SellIn = 5
            };

            var rose = new GildedRose(new[] { item });
            rose.UpdateQuality();

            Assert.AreEqual(4, item.Quality);
        }

    }
}
