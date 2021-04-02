using System.Collections.Generic;

namespace CSharpKatas
{
    public class GildedRose
    {
        IList<Item> Items;
        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackStagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const int MaxQuality = 50;
        public const int MinQuality = 0;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public class ItemFactory
        {
            public ISpecificItem Create(Item item)
            {
                switch (item.Name)
                {
                    case AgedBrie: return new AgedBrieItem(item);
                    default: return new OrdinaryItem(item);
                }
            }
        }

        public interface ISpecificItem
        {
            void UpdateQuality();
        }

        public class AgedBrieItem : ISpecificItem
        {
            private Item item;
            public AgedBrieItem(Item item)
            {
                this.item = item;
            }

            public void UpdateQuality()
            {
                // TODO: implement
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != AgedBrie && Items[i].Name != BackStagePass)
                {
                    if (Items[i].Quality > MinQuality)
                    {
                        if (Items[i].Name != Sulfuras)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < MaxQuality)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == BackStagePass)
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < MaxQuality)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < MaxQuality)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != Sulfuras)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < MinQuality)
                {
                    if (Items[i].Name != AgedBrie)
                    {
                        if (Items[i].Name != BackStagePass)
                        {
                            if (Items[i].Quality > MinQuality)
                            {
                                if (Items[i].Name != Sulfuras)
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < MaxQuality)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}