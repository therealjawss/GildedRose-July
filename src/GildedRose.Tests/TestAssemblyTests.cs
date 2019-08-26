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
                
            };
            var Items = new List<Item>
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
                            SellIn = 10,
                            Quality = 20
                        },
                     new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 5,
                            Quality = 20
                        },
                };
            app.SetItems(Items);
            app.UpdateQuality();

            Items[0].SellIn.Should().Be(9);
            Items[1].SellIn.Should().Be(1);
            Items[2].SellIn.Should().Be(4);
            Items[3].SellIn.Should().Be(0);
            Items[4].SellIn.Should().Be(14);
            Items[5].SellIn.Should().Be(2);

            Items[0].Quality.Should().Be(19);
            Items[1].Quality.Should().Be(1);
            Items[2].Quality.Should().Be(6);
            Items[3].Quality.Should().Be(80);
            Items[4].Quality.Should().Be(21);
            Items[5].Quality.Should().Be(5);
            Items[6].Quality.Should().Be(22);
            Items[7].Quality.Should().Be(23);


        }
    }
}