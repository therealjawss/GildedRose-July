using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class NormalItemProcessor : ItemProcessor
    {
        public NormalItemProcessor(Item item) : base(item)
        {
        }

        public override void UpdateState()
        {
           
            if (Item.Quality > 0)
            {
                Item.Quality = Item.Quality - 1;
            }
           
            Item.SellIn = Item.SellIn - 1;
          
            if (Item.SellIn < 0)
            {
                if (Item.Quality > 0 )
                {
                    Item.Quality = Item.Quality - 1;
                }
                  
            }
        }
    }
}
