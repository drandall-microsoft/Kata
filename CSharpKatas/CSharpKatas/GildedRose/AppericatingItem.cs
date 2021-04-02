using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.GildedRose
{
    internal abstract class AppericatingItem : ISpecificItem
    {
        protected Item item;

        public AppericatingItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            item.Quality = Math.Min(GildedRose.MaxQuality, item.Quality + 1);
            item.SellIn--;
        }
    }
}
