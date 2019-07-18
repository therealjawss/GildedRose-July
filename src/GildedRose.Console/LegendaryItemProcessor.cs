using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class LegendaryItemProcessor : ItemProcessor
    {
        public LegendaryItemProcessor(Item item) : base(item)
        {
        }

        public override void UpdateState()
        {
            //Do nothing for LegendaryItems

        }
    }
}
