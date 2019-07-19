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
    public class ItemProcessorTests
    {

        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 20, 9, 19)]
        [InlineData("+5 Dexterity Vest", 10, 0, 9, 0)]
        [InlineData("+5 Dexterity Vest", 0, 20, -1, 18)]
        [InlineData("Elixir of the Mongoose", 5, 7, 4, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [InlineData("Conjured Mana Cake", 3, 6, 2, 4)] 
        [InlineData("Conjured Mana Cake", 0, 6, -1, 2)]
        [InlineData("Conjured Mana Cake", 0, 2, -1, 0)]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Aged Brie", 2, 50, 1, 50)]
        [InlineData("Aged Brie", 0, 40, -1, 42)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 20, 10, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 20, 9, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 20, 5, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 20, 4, 23)]

        [InlineData("Backstage passes to a TAFKAL80ETC concert", 3, 49, 2, 50)]

        public void ShouldProcessSellinAndQualityAsPrescribed(string name, int sellin, int quality, int newsellin, int newquality)
        {
            var item = new Item { Name = name, Quality = quality, SellIn = sellin };

            ItemProcessor.GetInstanceFor(item).UpdateItemQuality(item);
            item.Name.Should().Be(name);
            item.Quality.Should().Be(newquality);
            item.SellIn.Should().Be(newsellin);
        }


        [Theory]
        [InlineData("Aged Brie", Category.AgedBrie)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", Category.BackstagePasses)]
        [InlineData("Sulfuras, Hand of Ragnaros", Category.LegendaryItem)]
        [InlineData("Conjured Mana Cake", Category.ConjuredItem)]
        [InlineData("+5 Dexterity Vest", Category.NormalItem)]
        [InlineData("Elixir of the Mongoose", Category.NormalItem)]
        public void CanGetItemCategoryFromItemName(string name, Category expectedcategory)
        {
            var item = new Item { Name = name };
            var category = ItemProcessor.GetCategory(item);
            category.Should().Be(expectedcategory);
        }

        [Fact]
        public void CreatesAgedBrieProcessorForAgedBrie()
        {
            var item = new Item { Name = "Aged Brie" };
            var processor = ItemProcessor.GetInstanceFor(item);
            processor.Should().NotBeNull();
            processor.Should().BeOfType<AgedBrieProcessor>();
        }
        [Fact]
        public void CreatesBackstagePassProcessorForBackstagePasses()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert" };

            var processor = ItemProcessor.GetInstanceFor(item);
            processor.Should().NotBeNull();
            processor.Should().BeOfType<BackstagePassProcessor>();
        }

        [Fact]
        public void NormalItemProcessorForNormalItems()
        {
            var item = new Item { Name = "Some Random Item" };
            var processor = ItemProcessor.GetInstanceFor(item);
            processor.Should().NotBeNull();
            processor.Should().BeOfType<NormalItemProcessor>();
        }

        [Fact]
        public void LegendaryItemProcessorForLegendaryItems()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros" };
            var processor = ItemProcessor.GetInstanceFor(item);
            processor.Should().NotBeNull();
            processor.Should().BeOfType<LegendaryItemProcessor>();
        }

        [Fact]
        public void ConjuredItemProcessorForConjuredItems()
        {
            var item = new Item { Name = "Conjured Mana Cake" };
            var processor = ItemProcessor.GetInstanceFor(item);
            processor.Should().NotBeNull();
            processor.Should().BeOfType<ConjuredItemProcessor>();
        }
        
    }
}

