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
        public void TestWhatTheAppDoesToday()
        {
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
                            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                        };
            Program program = new Program(items);

            program.UpdateQuality();

            var changedItems = program.GetItems();

            changedItems[0].Name.Should().Be("+5 Dexterity Vest");
            changedItems[0].SellIn.Should().Be(9);
            changedItems[0].Quality.Should().Be(19);

            changedItems[1].Name.Should().Be("Aged Brie");
            changedItems[1].SellIn.Should().Be(1);
            changedItems[1].Quality.Should().Be(1);

            changedItems[2].Name.Should().Be("Elixir of the Mongoose");
            changedItems[2].SellIn.Should().Be(4);
            changedItems[2].Quality.Should().Be(6);

            changedItems[3].Name.Should().Be("Sulfuras, Hand of Ragnaros");
            changedItems[3].SellIn.Should().Be(0);
            changedItems[3].Quality.Should().Be(80);

            changedItems[4].Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            changedItems[4].SellIn.Should().Be(14);
            changedItems[4].Quality.Should().Be(21);

            changedItems[5].Name.Should().Be("Conjured Mana Cake");
            changedItems[5].SellIn.Should().Be(2);
            changedItems[5].Quality.Should().Be(4);

        }
    }
}