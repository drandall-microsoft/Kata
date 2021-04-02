using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.GildedRose
{
    internal class OrdinaryItem : ISpecificItem
    {
        private Item item;

        public OrdinaryItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            item.Quality = Math.Max(GildedRose.MinQuality, item.Quality - 1);
            item.SellIn--;
        }
    }
}
