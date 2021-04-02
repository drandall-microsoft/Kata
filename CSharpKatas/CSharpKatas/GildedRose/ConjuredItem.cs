using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.GildedRose
{
    internal class ConjuredItem : ISpecificItem
    {
        protected Item item;

        public ConjuredItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            item.Quality = Math.Max(GildedRose.MinQuality, item.Quality - (GildedRose.DevalueRate * 2));
            item.SellIn--;
        }
    }
}
