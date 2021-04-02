using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.GildedRose
{
    internal class AgedBrie : ISpecificItem
    {
        private Item item;

        public AgedBrie(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            item.Quality = Math.Min(GildedRose.MaxQuality, item.Quality++);
            item.SellIn--;
        }
    }
}
