using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ConjuredItemProcessor: ItemProcessor
    {
        public override void UpdateItemQuality(Item item)
        {
            if (--item.SellIn < 0)
                item.Quality -= 4;
            else
                item.Quality -= 2;
                    
            item.Quality = item.Quality < 0 ? 0 : item.Quality;
        }
    }
}
