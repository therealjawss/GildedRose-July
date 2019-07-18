﻿using System;
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
            Item.Quality -= (--Item.SellIn < 0 ? 2 : 1);
            base.UpdateState();
        }
    }
}