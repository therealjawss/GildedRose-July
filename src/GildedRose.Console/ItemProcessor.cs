
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

            Item.Quality = Item.Quality < 0 ? 0 : Item.Quality;
            Item.Quality = Item.Quality > 50 ? 50 : Item.Quality;

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