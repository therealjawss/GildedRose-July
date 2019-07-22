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
    public class ItemProcessorShould
    {

        [Fact]
        public void GetCategoryFromItemName() {
 
            ItemProcessor.GetCategory(new Item { Name = NameConstants.BRIE }).Should().Be(Category.Brie);
            ItemProcessor.GetCategory(new Item { Name = NameConstants.VEST }).Should().Be(Category.NormalItem);
            ItemProcessor.GetCategory(new Item { Name = NameConstants.PASSES }).Should().Be(Category.BackstagePasses);
            ItemProcessor.GetCategory(new Item { Name = NameConstants.SULFURAS }).Should().Be(Category.LegendaryItem);
            ItemProcessor.GetCategory(new Item { Name = NameConstants.CONJURED }).Should().Be(Category.ConjuredItem);
            
            ItemProcessor.GetCategory(new Item { Name = NameConstants.ELIXIR }).Should().Be(Category.NormalItem);
            ItemProcessor.GetCategory(new Item { Name = "Random Item" }).Should().Be(Category.NormalItem);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ProcessItemsAsPrescribed(string name, int sellin, int quality, int newSellin, int newQuality)
        {
            var item = new Item { Name = name, Quality = quality, SellIn = sellin }; ;
            ItemProcessor.GetInstanceFor(item).ProcessItem(item);
            item.Quality.Should().Be(newQuality);
            item.SellIn.Should().Be(newSellin);
        }

        [Fact]
        public void CreateSpecificProcessorsBasedOnCategory() {
            ItemProcessor.GetInstanceFor(new Item { Name = NameConstants.BRIE }).Should().BeOfType<AgedBrieProcessor>();
            ItemProcessor.GetInstanceFor(new Item { Name = NameConstants.PASSES }).Should().BeOfType<BackstagePassesProcessor>();
            ItemProcessor.GetInstanceFor(new Item { Name = NameConstants.SULFURAS}).Should().BeOfType<LegendaryItemProcessor>();
            ItemProcessor.GetInstanceFor(new Item { Name = NameConstants.CONJURED }).Should().BeOfType<ConjuredItemProcessor>();
            ItemProcessor.GetInstanceFor(new Item { Name = "Another random item" }).Should().BeOfType<NormalItemProcessor>();
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AgedBrieProcessorShouldOnlyProcessAgedBrieItems(string name, int sellin, int quality, int newsellin, int newquality) {
            var item = new Item() { Name = name };

            var processor = ItemProcessor.GetInstanceFor(item);
            if (ItemProcessor.GetCategory(item) == Category.Brie)
            {
                processor.Should().BeOfType<AgedBrieProcessor>();
            }
            else
            {
                processor.Should().NotBeOfType<AgedBrieProcessor>();
            }
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void BackstagePassesProcessorShouldOnlyProcessBackstagePassess(string name, int sellin, int quality, int newsellin, int newquality)
        {
            var item = new Item() { Name = name };

            var processor = ItemProcessor.GetInstanceFor(item);
            if (ItemProcessor.GetCategory(item) == Category.BackstagePasses)
            {
                processor.Should().BeOfType<BackstagePassesProcessor>();
            }
            else
            {
                processor.Should().NotBeOfType<BackstagePassesProcessor>();
            }
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void LegendaryItemsProcessorShouldOnlyProcessLegendary(string name, int sellin, int quality, int newsellin, int newquality)
        {
            var item = new Item() { Name = name };

            var processor = ItemProcessor.GetInstanceFor(item);
            if (ItemProcessor.GetCategory(item) == Category.LegendaryItem)
            {
                processor.Should().BeOfType<LegendaryItemProcessor>();
            }
            else
            {
                processor.Should().NotBeOfType<LegendaryItemProcessor>();
            }
        }
        
        [Theory]
        [MemberData(nameof(TestData))]
        public void NormalItemsProcessorShouldOnlyProcessNormal(string name, int sellin, int quality, int newsellin, int newquality)
        {
            var item = new Item() { Name = name };

            var processor = ItemProcessor.GetInstanceFor(item);
            if (ItemProcessor.GetCategory(item) == Category.NormalItem)
            {
                processor.Should().BeOfType<NormalItemProcessor>();
            }
            else
            {
                processor.Should().NotBeOfType<NormalItemProcessor>();
            }
        }


        public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { NameConstants.VEST, 10, 20,9,19 },
            new object[] { NameConstants.VEST, 10, 0,9, 0 },
            new object[] { NameConstants.VEST, 0, 20,-1,18 },
            new object[] { NameConstants.BRIE, 2,0,1,1 },
            new object[] { NameConstants.BRIE, 2,50,1,50 },
            new object[] { NameConstants.BRIE, 0,0,-1,2 },
            new object[] { NameConstants.ELIXIR, 5,7,4,6 },
            new object[] { NameConstants.SULFURAS, 0,80,0,80},
            new object[] { NameConstants.SULFURAS, -1, 80, -1,80},
            new object[] { NameConstants.PASSES, 15,20,14,21 },
            new object[] { NameConstants.PASSES, 15,50,14,50 },
            new object[] { NameConstants.PASSES, 10,20,9,22 },
            new object[] { NameConstants.PASSES, 11,20,10,21 },
            new object[] { NameConstants.PASSES, 5,20,4,23},
            new object[] { NameConstants.PASSES, 6,20,5,22},
            new object[] { NameConstants.PASSES, 6,50,5,50},
            new object[] { NameConstants.PASSES, 6,49,5,50},
            new object[] { NameConstants.PASSES, 0,20,-1,0 },
            new object[] { NameConstants.CONJURED, 3, 6, 2,5 },
        };

    }
}
