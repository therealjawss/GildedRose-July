using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ConjuredItemProcessor : ItemProcessor
    {
        public ConjuredItemProcessor(Item item) : base(item)
        {
        }

        public override void UpdateState()
        {
            Item.SellIn -= 1;
            if (Item.Quality > 0) {
                Item.Quality -= 2;
            }
            if (Item.SellIn < 0)
            {
                Item.Quality -= 2;
            }
            Item.Quality = Item.Quality < 0 ? 0 : Item.Quality;

        }
    }
}
