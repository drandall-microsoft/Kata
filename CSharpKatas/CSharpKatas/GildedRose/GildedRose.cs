using System.Collections.Generic;

namespace CSharpKatas.GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackStagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const string Conjured = "Conjured";
        public const int MaxQuality = 50;
        public const int MinQuality = 0;
        public const int DevalueRate = 1;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var factory = new SpecificItemFactory();

            foreach (var item in Items)
            {
                factory.Create(item).UpdateQuality();
            }
        }
    }
}