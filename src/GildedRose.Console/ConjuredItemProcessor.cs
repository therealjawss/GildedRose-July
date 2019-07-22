using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ConjuredItemProcessor: ItemProcessor
    {
        public override void ProcessItem(Item item)
        {
            if (--item.SellIn < 0)
                item.Quality = item.Quality - 4;
            else
                item.Quality = item.Quality - 2;

            if (item.Quality < 0)
                item.Quality = 0;
        }
    }
}
