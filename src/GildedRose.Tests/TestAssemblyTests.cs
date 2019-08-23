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

            var app = new Program()
            {
                TheItems = new List<Item>
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
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 11,
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
                }

            };
            app.UpdateQuality();
            app.TheItems[0].SellIn.Should().Be(9);
            app.TheItems[0].Quality.Should().Be(19);

            app.TheItems[1].SellIn.Should().Be(1);
            app.TheItems[1].Quality.Should().Be(1);

            app.TheItems[2].SellIn.Should().Be(4);
            app.TheItems[2].Quality.Should().Be(6);

            app.TheItems[3].SellIn.Should().Be(0);
            app.TheItems[3].Quality.Should().Be(80);

            app.TheItems[4].SellIn.Should().Be(14);
            app.TheItems[4].Quality.Should().Be(21);

            app.TheItems[5].SellIn.Should().Be(2);
            app.TheItems[5].Quality.Should().Be(5);
            app.TheItems[6].SellIn.Should().Be(10);
            app.TheItems[6].Quality.Should().Be(21);

            app.TheItems[7].SellIn.Should().Be(9);
            app.TheItems[7].Quality.Should().Be(22);

            app.TheItems[8].SellIn.Should().Be(4);
            app.TheItems[8].Quality.Should().Be(23);
            app.TheItems[9].SellIn.Should().Be(0);
            app.TheItems[9].Quality.Should().Be(23);
            app.TheItems[10].SellIn.Should().Be(-1);
            app.TheItems[10].Quality.Should().Be(0);


        }

        public void CanGetItemType() { 

        }
    }
}