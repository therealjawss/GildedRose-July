using FluentAssertions;
using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }
        [Fact]

        public void TestHowTheOriginalAppProcessesData()
        {


        var program = new Program();
            var items = new List<Item>
                            {
                                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                new Item
                                    {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 15,
                                    Quality = 20
                                    },
                                new Item
                                    {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 10,
                                    Quality = 20
                                    },
                                new Item
                                    {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 5,
                                    Quality = 20
                                    },
                                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                                new Item {Name = "Another Item", SellIn = 1, Quality = 6},
                                new Item {Name = "Another Item", SellIn = 0, Quality = 6},
                                new Item
                                    {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 1,
                                    Quality = 20
                                    },
                                new Item
                                    {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 0,
                                    Quality = 20
                                    },
                                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                                new Item {Name = "Aged Brie", SellIn = 1, Quality = 0},
                                new Item {Name = "Aged Brie", SellIn = 0, Quality = 0},
                            };
            program.SetItems(items);
            program.UpdateQuality();
            items[0].Name.Should().Be("+5 Dexterity Vest");
            items[0].SellIn.Should().Be(9);
            items[0].Quality.Should().Be(19);

            items[1].Name.Should().Be("Aged Brie");
            items[1].SellIn.Should().Be(1);
            items[1].Quality.Should().Be(1);

            items[2].Name.Should().Be("Elixir of the Mongoose");
            items[2].SellIn.Should().Be(4);
            items[2].Quality.Should().Be(6);

            items[3].Name.Should().Be("Sulfuras, Hand of Ragnaros");
            items[3].SellIn.Should().Be(0);
            items[3].Quality.Should().Be(80);

            items[4].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            items[4].SellIn.Should().Be(14);
            items[4].Quality.Should().Be(21);

            items[5].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            items[5].SellIn.Should().Be(9);
            items[5].Quality.Should().Be(22);

            items[6].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            items[6].SellIn.Should().Be(4);
            items[6].Quality.Should().Be(23);

            items[7].Name.Should().Be("Conjured Mana Cake");
            items[7].SellIn.Should().Be(2);
            items[7].Quality.Should().Be(4);

            items[8].Name.Should().Be("Another Item");
            items[8].SellIn.Should().Be(0);
            items[8].Quality.Should().Be(5);

            items[9].Name.Should().Be("Another Item");
            items[9].SellIn.Should().Be(-1);
            items[9].Quality.Should().Be(4);

            items[10].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            items[10].SellIn.Should().Be(0);
            items[10].Quality.Should().Be(23);

            items[11].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            items[11].SellIn.Should().Be(-1);
            items[11].Quality.Should().Be(0);

            items[12].Name.Should().Be("Sulfuras, Hand of Ragnaros");
            items[12].SellIn.Should().Be(-1);
            items[12].Quality.Should().Be(80);

            items[13].Name.Should().Be("Aged Brie");
            items[13].SellIn.Should().Be(0);
            items[13].Quality.Should().Be(1);

            items[14].Name.Should().Be("Aged Brie");
            items[14].SellIn.Should().Be(-1);
            items[14].Quality.Should().Be(2);

            program.GetItems().Should().BeEquivalentTo<Item>(items);
        }

        [Theory]
        [InlineData("Some item", 1, 1)]
        [InlineData("Some item again", 42, 42)]
        public void CanCreateItemProcessorFromItem(string name, int sellin, int quality)
        {
            var item = new Item() { Name = name, SellIn = sellin, Quality = quality };

            var processor = ItemProcessor.GetInstanceFor(item);

            processor.Should().NotBeNull();
            processor.Item.Name.Should().Be(item.Name);
            processor.Item.SellIn.Should().Be(item.SellIn);
            processor.Item.Quality.Should().Be(item.Quality);
        }

      

        [Theory]

        [InlineData("+5 Dexterity Vest", 10, 9, 20, 19)]
        [InlineData("Aged Brie", 2, 1, 0, 1)]
        [InlineData("Aged Brie", 2, 1, 49, 50)]
        [InlineData("Aged Brie", 2, 1, 50, 50)]
        [InlineData("Aged Brie", 0, -1, 50, 50)]
        [InlineData("Elixir of the Mongoose", 5, 4, 7, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 0, 80, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 14, 20, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 9, 20, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 4, 20, 23)]
        [InlineData("Conjured Mana Cake", 3, 2, 6, 4)]
        [InlineData("Another Item", 1, 0, 6, 5)]
        [InlineData("Another Item", 0, -1, 6, 4)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 0, 20, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, -1, 20, 0)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, -1, 80, 80)]
        [InlineData("Aged Brie", 1, 0, 0, 1)]
        [InlineData("Aged Brie", 0, -1, 0, 2)]
        public void IndividualItemUpdateShouldWorkTheSameAsOriginal(string name, int currsellin, int newsellin, int currquality, int newquality) {
            var item = new Item() { Name = name, SellIn = currsellin, Quality = currquality };
            Program.UpdateItemState(item);
            item.Name.Should().Be(name);
            item.SellIn.Should().Be(newsellin);
            item.Quality.Should().Be(newquality);
        }
    }
}