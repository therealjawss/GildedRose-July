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
            switch (GetCategory(item))
            {
                case Category.Brie:
                    return new AgedBrieProcessor();
                case Category.BackstagePasses:
                    return new BackstagePassesProcessor();
                case Category.LegendaryItem:
                    return new LegendaryItemProcessor();
                case Category.ConjuredItem:
                    return new ConjuredItemProcessor();
                case Category.NormalItem:
                    return new NormalItemProcessor();
                default:
                    return new ItemProcessor();
            }
        }

        public static Category GetCategory(Item item)
        {
            if (item.Name.Equals(NameConstants.BRIE))
                return Category.Brie;
            else if (item.Name.Equals(NameConstants.PASSES))
                return Category.BackstagePasses;
            else if (item.Name.Equals(NameConstants.SULFURAS))
                return Category.LegendaryItem;
            else if (item.Name.StartsWith(NameConstants.CONJURED))
                return Category.ConjuredItem;
            else
                return Category.NormalItem;
        }
    }
}
