using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class AgedBrieProcessor : ItemProcessor
    {
        public override void UpdateItemQuality(Item item)
        {
            if (--item.SellIn < 0)
            {
                item.Quality += 2;
            }
            else {
                item.Quality++;
            }
            item.Quality = (item.Quality > 50) ? 50 : item.Quality;
        }
    }
}
