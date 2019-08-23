using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ItemProcessor
    {
        public virtual void ProcessItem(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        public static ItemProcessor GetInstanceFor(Item item)
        {
            var type = GetType(item);

            switch (type)
            {
                case ItemType.Brie:
                    return new AgedBrieItemProcessor();
                case ItemType.Legendary:
                    return new LegendaryItemProcessor();
                case ItemType.BackstagePasses:
                    return new BackstagePassesItemProcessor();
                default:
                    return new NormalItemProcessor();
            }
        }

        public static ItemType GetType(Item item)
        {
            if (item.Name.StartsWith("Aged Brie"))
                return ItemType.Brie;
            else if (item.Name.StartsWith("Sulfuras"))
                return ItemType.Legendary;
            else if (item.Name.StartsWith("Backstage passes"))
                return ItemType.BackstagePasses;
            return ItemType.Normal;
        }
    }
}
