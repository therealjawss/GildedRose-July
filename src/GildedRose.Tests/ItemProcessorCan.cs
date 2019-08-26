using FluentAssertions;
using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemProcessorCan
    {
        [Theory]
        [InlineData("+5 Dexterity Vest", 9, 20, 8, 19)]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Elixir of the Mongoose", 5, 7, 4, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        [InlineData("Conjured Mana Cake", 3, 6, 2, 5)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 20, 9, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 20, 10, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 20, 4, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 20, 5, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 20, -1, 0)]
        public void ProcessItem(string name, int sellin, int quality,
            int expectedsellin, int expectedquality) {
            var item = new Item { Name = name, SellIn = sellin, Quality = quality };

            ItemProcessor.GetProcessorFor(item).Process(item);

            item.SellIn.Should().Be(expectedsellin);
            item.Quality.Should().Be(expectedquality);

        }

        [Theory]
        [InlineData("+5 Dexterity Vest", ItemType.NormalItem)]
        [InlineData("Aged Brie", ItemType.AgedBrie)]
        [InlineData("Sulfuras, Hand of Ragnaros", ItemType.Legendary)]
        [InlineData("Elixir of the Mongoose", ItemType.NormalItem)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", ItemType.BackstagePasses)]
        [InlineData("Conjured Mana Cake", ItemType.Conjured)]
        public void GetAnItemsType(string name, ItemType type)
        {
            var item = new Item { Name = name };
            var result = ItemProcessor.GetItemType(item);
            result.Should().BeOfType<ItemType>();
            result.Should().Be(type);
        }

        [Theory]
        [InlineData("+5 Dexterity Vest", typeof(NormalItemProcessor))]
        [InlineData("Aged Brie", typeof(AgedBrieProcessor))]
        [InlineData("Sulfuras, Hand of Ragnaros", typeof(LegendaryItemProcessor))]
        //[InlineData("Elixir of the Mongoose", ItemType.NormalItem)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(BackstageProcessor))]
        [InlineData("Conjured Mana Cake", typeof(ConjuredItemProcessor))]
        public void GetProcessorAccordingToType(string name, Type type)
        {
            var item = new Item { Name = name };
            var processor = ItemProcessor.GetProcessorFor(item);
            processor.Should().BeOfType(type);
            processor.Should().BeAssignableTo<ItemProcessor>();
        }

        [Theory]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Elixir of the Mongoose", 5, 7, 4, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 20, 9, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 20, 10, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 20, 4, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 20, 5, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 20, -1, 0)]
        public void CanProcessBrieAccordingToRules(string name, int sellin, int qual, int expsellin, int expqual)
        {
            var item = new Item { Name = name };
            var processor = ItemProcessor.GetProcessorFor(item);
            processor.Process(item);
            item.SellIn.Should().Be(expsellin);
            item.Quality.Should().Be(expqual);


        }
    }
}
