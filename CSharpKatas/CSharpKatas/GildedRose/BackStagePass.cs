using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.GildedRose
{
    internal class BackStagePass : ISpecificItem
    {
        private Item item;

        public BackStagePass(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            if (item.SellIn > 10)
            {
                item.Quality++;
            }
            else if (item.SellIn > 5)
            {
                item.Quality += 2;
            }
            else if (item.SellIn > 0)
            {
                item.Quality += 3;
            }
            else
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }
    }
}
