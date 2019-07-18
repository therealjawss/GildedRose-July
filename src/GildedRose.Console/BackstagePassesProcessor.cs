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

            Item.SellIn = Item.SellIn - 1;

            if (Item.Quality < 50)
            {
                Item.Quality = Item.Quality + 1;
                 
                if (Item.SellIn < 10 && Item.Quality < 50)
                {
                    Item.Quality = Item.Quality + 1;
                }

                if (Item.SellIn < 5 && Item.Quality < 50)
                {
                    Item.Quality = Item.Quality + 1;
                }
                  
            }
     
 
            if (Item.SellIn < 0)
            {              
               
                Item.Quality = Item.Quality - Item.Quality;
               
            }
        }
    }
}
