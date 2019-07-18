using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class BackstagePassesProcessor : ItemProcessor
    {
        public BackstagePassesProcessor(Item item) : base(item)
        {
        }

        public override void UpdateState()
        {
            --Item.SellIn;

            if (Item.SellIn < 0)
                Item.Quality = 0;
            else if (Item.SellIn < 5)
                Item.Quality += 3;
            else if (Item.SellIn < 10)
                Item.Quality += 2;
            else
                Item.Quality += 1;

            base.UpdateState();
        }
    }
}
