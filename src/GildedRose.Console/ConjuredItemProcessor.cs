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
            Item.Quality -= (--Item.SellIn < 0) ? 4 : 2;
            base.UpdateState();
        }
    }
}
