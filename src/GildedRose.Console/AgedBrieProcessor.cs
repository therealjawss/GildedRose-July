using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class AgedBrieProcessor : ItemProcessor
    {
        public override void ProcessItem(Item item)
        {
            if (--item.SellIn < 0)
            {
                item.Quality += 2;
            }
            else {
                item.Quality++;
            }

            if (item.Quality > 50) {
                item.Quality = 50;
            }
        }
    }
}
