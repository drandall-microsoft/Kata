using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.GildedRose
{
    internal class SpecificItemFactory
    {
        public ISpecificItem Create(Item item)
        {
            switch (item.Name)
            {
                case GildedRose.AgedBrie: return new AgedBrie(item);
                case GildedRose.Sulfuras: return new Sulfuras(item);
                case GildedRose.BackStagePass: return new BackStagePass(item);
                case GildedRose.Conjured: return new ConjuredItem(item);
                default: return new OrdinaryItem(item);
            }
        }
    }
}
