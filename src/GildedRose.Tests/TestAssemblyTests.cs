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
        public void ExistingProgramShouldRunAsPrescribed()
        {
            var items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15,Quality = 20},
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          };

            Program p = new Program(items);

            p.UpdateQuality();
            items[0].SellIn.Should().Be(9);
            items[1].SellIn.Should().Be(1);
            items[2].SellIn.Should().Be(4);
            items[3].SellIn.Should().Be(0);
            items[4].SellIn.Should().Be(14);
            items[5].SellIn.Should().Be(2);
            
            items[0].Quality.Should().Be(19);
            items[1].Quality.Should().Be(1);
            items[2].Quality.Should().Be(6);
            items[3].Quality.Should().Be(80);
            items[4].Quality.Should().Be(21);
            items[5].Quality.Should().Be(4);

        }

      
    }
}