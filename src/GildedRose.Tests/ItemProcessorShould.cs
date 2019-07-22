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
    class ItemProcessorShould
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ProcessItemsAsPrescribed(string name, int sellin, int quality, int newSellin, int newQuality)
        {
            var item = new Item { Name = name, Quality = quality, SellIn = sellin }; ;
            ItemProcessor.ProcessItem(item);
            item.Quality.Should().Be(newQuality);
            item.SellIn.Should().Be(newSellin);
        }

        public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[] { VEST, 10, 20,9,19 },
            new object[] { VEST, 10, 0,9, 0 },
            new object[] { VEST, 0, 20,-1,18 },
            new object[] { BRIE, 2,0,1,1 },
            new object[] { BRIE, 2,50,1,50 },
            new object[] { BRIE, 0,0,-1,2 },
            new object[] { ELIXIR, 5,7,4,6 },
            new object[] {SULFURAS, 0,80,0,80},
            new object[] {SULFURAS, -1, 80, -1,80},
            new object[] { PASSES, 15,20,14,21 },
            new object[] { PASSES, 15,50,14,50 },
            new object[] { PASSES, 10,20,9,22 },
            new object[] { PASSES, 11,20,10,21 },
            new object[] { PASSES, 5,20,4,23},
            new object[] { PASSES, 6,20,5,22},
            new object[] { PASSES, 6,50,5,50},
            new object[] { PASSES, 6,49,5,50},
            new object[] { PASSES, 0,20,-1,0 },
            new object[] {CONJURED, 3, 6, 2,5 },
        };


        public const string VEST = "+5 Dexterity Vest";
        public const string BRIE = "Aged Brie";
        public const string ELIXIR = "Elixir of the Mongoose";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string PASSES = "Backstage passes to a TAFKAL80ETC concert";
        public const string CONJURED = "Conjured Mana Cake";
    }
}
