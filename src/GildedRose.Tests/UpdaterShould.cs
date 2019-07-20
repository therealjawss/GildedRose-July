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

        public static IEnumerable<object[]> ItemsData => new List<object[]> {
            new object[] { TestConstants.BRIE},
            new object[] { TestConstants.CONJURED},
            new object[] { TestConstants.DEXTERITY},
        };
    }
}
