using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GildedRose.Console;
using FluentAssertions;
using System.ComponentModel;

namespace GildedRose.Tests
{
    public class ItemProcessorTests
    {

        [Theory]

        [InlineData("+5 Dexterity Vest", 10, 9, 20, 19)]
        [InlineData("+5 Dexterity Vest", 0, -1, 20, 18)]
        [InlineData("+5 Dexterity Vest", 0, -1, 0, 0)]
        [InlineData("Aged Brie", 2, 1, 0, 1)]
        [InlineData("Aged Brie", 2, 1, 49, 50)]
        [InlineData("Aged Brie", 2, 1, 50, 50)]
        [InlineData("Aged Brie", 0, -1, 50, 50)]
        [InlineData("Aged Brie", 1, 0, 0, 1)]
        [InlineData("Aged Brie", 0, -1, 0, 2)]
        [InlineData("Elixir of the Mongoose", 5, 4, 7, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 0, 80, 80)]
        [InlineData("Conjured Mana Cake", 3, 2, 6, 4)]
        [InlineData("Another Item", 1, 0, 6, 5)]
        [InlineData("Another Item", 0, -1, 6, 4)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, -1, 80, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 14, 20, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 9, 20, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 4, 20, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 0, 20, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, -1, 20, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 1, 48, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 1, 49, 50)]

        public void ItemProcessedAccordingToSpecifications(string name, int currsellin, int newsellin, int currquality, int newquality)
        {
            var item = new Item() { Name = name, SellIn = currsellin, Quality = currquality };

            var itemPreprocessor = ItemProcessor.GetInstanceFor(item);
            itemPreprocessor.UpdateState();
            itemPreprocessor.Item.Name.Should().Be(name);
            itemPreprocessor.Item.SellIn.Should().Be(newsellin);
            itemPreprocessor.Item.Quality.Should().Be(newquality);
        }

        [Theory]
        [InlineData("Aged Brie", ItemCategory.AgedBrie)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", ItemCategory.BackstagePasses), DisplayName("test")]
        [InlineData("Sulfuras, Hand of Ragnaros", ItemCategory.LegendaryItem)]
        [InlineData("Elixir of the Mongoose", ItemCategory.NormalItem)]
        [InlineData("Conjured Mana Cake", ItemCategory.ConjuredItem)]
        public void CanGetCategoryFromItem(string name, ItemCategory actualcategory)
        {
            var item = new Item() { Name = name };
            var itemProcessor = ItemProcessor.GetInstanceFor(item);
            ItemCategory category = ItemProcessor.GetItemCategory(item);
            category.Should().Be(actualcategory);
        }

        [Theory]
        [InlineData("Aged Brie", 2, 1, 0, 1)]
        [InlineData("Aged Brie", 2, 1, 49, 50)]
        [InlineData("Aged Brie", 2, 1, 50, 50)]
        [InlineData("Aged Brie", 0, -1, 50, 50)]
        [InlineData("Aged Brie", 1, 0, 0, 1)]
        [InlineData("Aged Brie", 0, -1, 0, 2)]
        public void CanProcessAgedBrie(string name, int currsellin, int newsellin, int currquality, int newquality)
        {
            var item = new Item { Name = name, Quality = currquality, SellIn = currsellin };
            var itemProcessor = ItemProcessor.GetInstanceFor(item);
            itemProcessor.GetType().Should().BeAssignableTo<AgedBrieProcessor>();
            itemProcessor.UpdateState();
            itemProcessor.Item.Quality.Should().Be(newquality);
            itemProcessor.Item.SellIn.Should().Be(newsellin);

        }

        [Theory]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 0, 80, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, -1, 80, 80)]
        public void CanProcessLegendaryItems(string name, int currsellin, int newsellin, int currquality, int newquality)
        {
            var item = new Item { Name = name, Quality = currquality, SellIn = currsellin };
            var itemProcessor = ItemProcessor.GetInstanceFor(item);
            itemProcessor.GetType().Should().BeAssignableTo<LegendaryItemProcessor>();
            itemProcessor.UpdateState();
            itemProcessor.Item.Quality.Should().Be(newquality);
            itemProcessor.Item.SellIn.Should().Be(newsellin);

        }

        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 14, 20, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 9, 20, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 4, 20, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 0, 20, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, -1, 20, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 1, 48, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 1, 49, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 10, 8, 9)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 9, 8, 10)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 5, 8, 10)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 4, 8, 11)]
        public void CanProcessBackstagePasses(string name, int currsellin, int newsellin, int currquality, int newquality)
        {
            var item = new Item { Name = name, Quality = currquality, SellIn = currsellin };
            var itemProcessor = ItemProcessor.GetInstanceFor(item);
            itemProcessor.GetType().Should().BeAssignableTo<BackstagePassesProcessor>();
            itemProcessor.UpdateState();
            itemProcessor.Item.Quality.Should().Be(newquality);
            itemProcessor.Item.SellIn.Should().Be(newsellin);

        }

        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 9, 20, 19)]
        [InlineData("+5 Dexterity Vest", 0, -1, 20, 18)]
        [InlineData("+5 Dexterity Vest", 0, -1, 0, 0)]
        public void CanProcessNormalItems(string name, int currsellin, int newsellin, int currquality, int newquality)
        {
            var item = new Item { Name = name, Quality = currquality, SellIn = currsellin };
            var itemProcessor = ItemProcessor.GetInstanceFor(item);
            itemProcessor.GetType().Should().BeAssignableTo<NormalItemProcessor>();
            itemProcessor.UpdateState();
            itemProcessor.Item.Quality.Should().Be(newquality);
            itemProcessor.Item.SellIn.Should().Be(newsellin);
        }

        [Theory]
        [InlineData("Conjured Mana Cake", 3, 2, 6, 4)]
        public void CanProcessConjuredItems(string name, int currsellin, int newsellin, int currquality, int newquality)
        {
            var item = new Item { Name = name, Quality = currquality, SellIn = currsellin };
            var itemProcessor = ItemProcessor.GetInstanceFor(item);
            itemProcessor.GetType().Should().BeAssignableTo<ConjuredItemProcessor>();
            itemProcessor.UpdateState();
            itemProcessor.Item.Quality.Should().Be(newquality);
            itemProcessor.Item.SellIn.Should().Be(newsellin);
        }

    }
}
