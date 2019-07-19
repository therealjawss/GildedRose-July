using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class BackstagePassProcessor : ItemProcessor
    {
        public override void UpdateItemQuality(Item item)
        {
            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
            else if (item.SellIn < 5)
            {
                item.Quality += 3;
            }
            else if (item.SellIn < 10)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality += 1;
            }


            item.Quality = (item.Quality > 50) ? 50 : item.Quality;
        }
    }
}
