using FluentAssertions;
using GildedRose.Console;
using System;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemProcessorCan
    {
        [Theory]
        [InlineData("+5 Dexterity Vest", ItemType.Normal)]
        [InlineData("Aged Brie", ItemType.Brie)]
        [InlineData("Elixir of the Mongoose", ItemType.Normal)]
        [InlineData("Sulfuras, Hand of Ragnaros", ItemType.Legendary)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", ItemType.BackstagePasses)]
        //[InlineData("Conjured Mana Cake", ItemType.Conjured)]
        public void GetItemType(string name, ItemType type) {
            var item = new Item() { Name = name };
            var result = ItemProcessor.GetType(item);

            result.Should().BeOfType<ItemType>();
            result.Should().Be(type);
        }

        [Theory]
        [InlineData("Aged Brie", typeof(AgedBrieItemProcessor))]
        [InlineData("+5 Dexterity Vest", typeof(NormalItemProcessor))]
        [InlineData("Sulfuras, Hand of Ragnaros", typeof(LegendaryItemProcessor))]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassesItemProcessor))]
        public void GetSpecificInstanceOfProcessorBasedOnType(string name, Type type ) {
            var item = new Item() { Name = name};

            var processor = ItemProcessor.GetInstanceFor(item);
            processor.Should().BeOfType(type);
        }

        public void ProcessBrieItemsAccordingToRules() {
            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            ItemProcessor processor = ItemProcessor.GetInstanceFor(brie);
            processor.ProcessItem(brie);
        }
    }
}
