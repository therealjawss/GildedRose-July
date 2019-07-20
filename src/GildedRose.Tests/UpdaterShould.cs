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
    public class UpdaterShould
    {
        [Theory]
        [MemberData(nameof(ItemsData))]
        public void CreateAnUpdaterForItems(string name) {
            var updater = new Updater();
            updater.Should().NotBeNull();
        }
        [Theory]
        [MemberData(nameof(ItemsCategoryData))]
        public void GetCategoryForItems(string name, Category expectedcategory) {
            var item = new Item {Name = name} ;
            var category = Updater.GetCategoryFor(item);
            category.Should().Be(expectedcategory);
        }
              
        public static IEnumerable<object[]> ItemsData => new List<object[]> {
            new object[] { TestConstants.BRIE},
            new object[] { TestConstants.CONJURED},
            new object[] { TestConstants.DEXTERITY},
            new object[] { TestConstants.SULFURAS},
            new object[] { TestConstants.ELIXIR},
            new object[] { TestConstants.PASSES }
        };

        public static IEnumerable<object[]> ItemsCategoryData => new List<object[]> {
            new object[] { TestConstants.BRIE, Category.AgedBrie},
            new object[] { TestConstants.CONJURED, Category.ConjuredItem},
            new object[] { TestConstants.DEXTERITY, Category.Normal},
            new object[] { TestConstants.SULFURAS, Category.LegendaryItem},
            new object[] { TestConstants.ELIXIR, Category.Normal},
            new object[] { TestConstants.PASSES, Category.BackstagePasses }
        };
    }
}
