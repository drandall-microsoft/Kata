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
                default: return new OrdinaryItem(item);
            }
        }
    }
}
