using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class NormalItemProcessor : ItemProcessor
    {
        public override void Process(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }



            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {

                if (item.Quality > 0)
                {

                    item.Quality = item.Quality - 1;

                }


            }
        }
    }
}
