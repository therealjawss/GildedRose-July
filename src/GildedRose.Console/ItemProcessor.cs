using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ItemProcessor
    {
        public  virtual void UpdateItemQuality(Item item)
        {
            throw new Exception("Unknown Item Type");
        }

        public static Category GetCategory(Item item)
        {
            if (item.Name.Equals("Aged Brie"))
                return Category.AgedBrie;
            else if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                return Category.BackstagePasses;
            else if (item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                return Category.LegendaryItem;
            else if (item.Name.Equals("Conjured Mana Cake"))
                return Category.ConjuredItem;
            else
                return Category.NormalItem;
        }

        public static ItemProcessor GetInstanceFor(Item item)
        {
            if (GetCategory(item) == Category.AgedBrie)
                return new AgedBrieProcessor();
            else if (GetCategory(item) == Category.BackstagePasses)
                return new BackstagePassProcessor();
            else if (GetCategory(item) == Category.NormalItem)
                return new NormalItemProcessor();
            else if (GetCategory(item) == Category.LegendaryItem)
                return new LegendaryItemProcessor();
            else if (GetCategory(item) == Category.ConjuredItem)
                return new ConjuredItemProcessor();
            else
                return new ItemProcessor();
        }
    }
}
