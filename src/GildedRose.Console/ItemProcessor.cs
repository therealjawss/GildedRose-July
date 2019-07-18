
using System;

namespace GildedRose.Console
{
    public class ItemProcessor
    {
        public Item Item { get; set; }
        protected ItemProcessor(Item item)
        {
            this.Item = item;
        }

        public static ItemProcessor GetInstanceFor(Item item) {
            switch (GetItemCategory(item))
            {
                case ItemCategory.AgedBrie:
                    return new AgedBrieProcessor(item);
                case ItemCategory.LegendaryItem:
                    return new LegendaryItemProcessor(item);
                case ItemCategory.BackstagePasses:
                    return new BackstagePassesProcessor(item);
                case ItemCategory.NormalItem:
                    return new NormalItemProcessor(item);
                case ItemCategory.ConjuredItem:
                    return new ConjuredItemProcessor(item);
                default:
                    return new ItemProcessor(item);
            }
        }

        public virtual void UpdateState()
        {
            if (GetItemCategory(Item)==ItemCategory.AgedBrie || GetItemCategory(Item)==ItemCategory.BackstagePasses)
            {
                if (Item.Quality < 50)
                {
                    Item.Quality = Item.Quality + 1;

                    if (GetItemCategory(Item)==ItemCategory.BackstagePasses)
                    {
                        if (Item.SellIn < 11 && Item.Quality < 50)
                        {
                            Item.Quality = Item.Quality + 1;
                        }

                        if (Item.SellIn < 6 && Item.Quality < 50)
                        {
                            Item.Quality = Item.Quality + 1;
                        }
                    }
                }
            }
            else
            {
                if (Item.Quality > 0 && !(GetItemCategory(Item)==ItemCategory.LegendaryItem))
                {
                    Item.Quality = Item.Quality - 1;
                }
            }

            if (!(GetItemCategory(Item) == ItemCategory.LegendaryItem))
            {
                Item.SellIn = Item.SellIn - 1;
            }

            if (Item.SellIn < 0)
            {
                if (GetItemCategory(Item)==ItemCategory.AgedBrie)
                {
                    if (Item.Quality < 50)
                    {
                        Item.Quality = Item.Quality + 1;
                    }
                }
                else
                {
                    if (GetItemCategory(Item) == ItemCategory.BackstagePasses)
                    {
                        Item.Quality = Item.Quality - Item.Quality;
                    }
                    else
                    {
                        if (Item.Quality > 0 && !(GetItemCategory(Item) == ItemCategory.LegendaryItem))
                        {
                            Item.Quality = Item.Quality - 1;
                        }
                    }
                }
            }
        }

        public static ItemCategory GetItemCategory(Item item)
        {
            if (itemNameStartsWith(item, "aged brie"))
            {
                return ItemCategory.AgedBrie;
            }
            else if (itemNameStartsWith(item, "backstage passes"))
            {
                return ItemCategory.BackstagePasses;
            }
            else if (itemNameStartsWith(item, "sulfuras"))
            {
                return ItemCategory.LegendaryItem;
            }
            else if (itemNameStartsWith(item, "conjured"))
            {
                return ItemCategory.ConjuredItem;
            }
            else
            {
                return ItemCategory.NormalItem;
            }
        }

        private static bool itemNameStartsWith(Item item, string name)
        {
            return item.Name.ToLower().StartsWith(name.ToLower());
        }
    }
}