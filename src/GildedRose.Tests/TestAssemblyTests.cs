using FluentAssertions;
using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        const string DEXTERITY = "+5 Dexterity Vest";
        const string BRIE = "Aged Brie";
        const string ELIXIR = "Elixir of the Mongoose";
        const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        const string PASSES = "Backstage passes to a TAFKAL80ETC concert";
        const string CONJURED = "Conjured Mana Cake";

        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        public void TestCurrentBehavor()
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
            items[5].Quality.Should().Be(5);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void UpdateItemQualityAccordingToSpecs(string name, int sellin, int quality, int newquality)
        {
            var item = new Item { Name = name, SellIn = sellin, Quality = quality };
            Program program = new Program();
            program.UpdateItemQuality(item);
            item.SellIn.Should().Be(name.Equals(SULFURAS) ? 0 : sellin - 1);
            item.Quality.Should().Be(newquality);

        }

        public static IEnumerable<object[]> Data => new List<object[]> {
            new object[]{ DEXTERITY, 10, 20, 19 },
            new object[]{ DEXTERITY, 0, 20, 18 },
            new object[]{ BRIE, 2, 0, 1 },
            new object[]{ BRIE, 2, 50, 50 },
            new object[]{ BRIE, -1, 20, 22 },
            new object[]{ BRIE, 0, 50, 50 },
            new object[]{ ELIXIR, 5, 7, 6 },
            new object[]{ ELIXIR, 0, 7, 5 },
            new object[]{ ELIXIR, 0, 49, 47 },
            new object[]{ ELIXIR, -1, 1,0  },
            new object[]{ ELIXIR, -1, 10, 8  },
            new object[]{ SULFURAS, 0, 80, 80 },
            new object[]{ PASSES, 15, 20, 21 },
            new object[]{ PASSES, 11, 20, 21 },
            new object[]{ PASSES, 10, 20, 22 },
            new object[]{ PASSES, 6, 20, 22 },
            new object[]{ PASSES, 5, 20, 23 },
            new object[]{ PASSES, 11, 49, 50 },
            new object[]{ PASSES, 10, 49, 50 },
            new object[]{ PASSES, 6, 49, 50 },
            new object[]{ PASSES, 5, 49, 50 },
            new object[]{ PASSES, 0, 49, 0 },
            new object[]{ PASSES, -1, 20, 0 },
            new object[]{ CONJURED, 3, 6, 5 },
        };
    }
}