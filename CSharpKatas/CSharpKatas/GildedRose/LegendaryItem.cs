using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.GildedRose
{
    internal abstract class LegendaryItem : ISpecificItem
    {
        protected Item item;

        public LegendaryItem(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
        }
    }
}
