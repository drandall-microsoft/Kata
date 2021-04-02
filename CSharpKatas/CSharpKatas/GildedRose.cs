using System.Collections.Generic;

namespace CSharpKatas
{
    public class GildedRose
    {
        IList<Item> Items;
        public static string AgedBrie { get; } = "Aged Brie";
        public static string Sulfuras { get; } = "Sulfuras, Hand of Ragnaros";
        public static string BackStagePass { get; } = "Backstage passes to a TAFKAL80ETC concert";
        public static int MaxQuality { get; } = 50;
        public static int MinQuality { get; } = 0;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
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