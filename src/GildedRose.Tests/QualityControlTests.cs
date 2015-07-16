// ReSharper disable InconsistentNaming
namespace GildedRose.Tests
{
    using System.Collections.Generic;

    using GildedRose.Console;
    using Item = Console.Program.Item;

    using Xunit;

    public class TestBase
    {
        protected Item Item { get; set; }
        protected QualityControl QualityControl { get; set; }
        protected List<Item> Items { get; set; }

        public TestBase()
        {
            this.QualityControl = new QualityControl();
            this.Items = new List<Item>();
        }

        protected void SetupItem(string name, int quality, int sellIn)
        {
            this.Item = new Item() {Name = name, Quality = quality, SellIn = sellIn};
            this.Items.Add(Item);
        }
    }

    public class GivenAStandardItem : TestBase
    {
        public GivenAStandardItem()
        {
            SetupItem("My Item", 10, 5);
        }

        [Fact]
        public void UpdateQuality_ShouldDecreaseQualityBy1()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(9, this.Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldDecreaseSelInBy1()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(4, this.Item.SellIn);
        }
    }

    public class WhenSellInIsZero : TestBase
    {
        public WhenSellInIsZero()
        {
            SetupItem("My Item", 10, 0);
        }

        [Fact]
        public void UpdateQuality_ShouldDecreaseQualityBy2()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(8, Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldDecreaseSelInBy1()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(-1, Item.SellIn);
        }
    }

    public class WhenQualityIsZero : TestBase
    {
        public WhenQualityIsZero()
        {
            SetupItem("My Item", 0, 10);
        }

        [Fact]
        public void UpdateQuality_ShouldNotAlterQuality()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(0, Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldDecreaseSellInBy1()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(9, Item.SellIn);
        }
    }

    public class GivenAgedBrie : TestBase
    {
        public GivenAgedBrie()
        {
            SetupItem("Aged Brie", 10, 10);
        }

        [Fact]
        public void UpdateQuality_ShouldIncreaseQualityBy1()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(11, Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldNotIncreaseQualityByMoreThan50()
        {
            Item.Quality = 50;
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(50, Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldDecreaseSelInBy1()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(9, Item.SellIn);
        }
    }

    public class GivenSulfuras : TestBase
    {
        public GivenSulfuras()
        {
            SetupItem("Sulfuras, Hand of Ragnaros", 80, 10);
        }

        [Fact]
        public void UpdateQuality_ShouldNotAlterQuality()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(80, Item.Quality);
        }

        [Fact]
        public void WhenSellInIsNegative_UpdateQuality_ShouldNotAlterQuality()
        {
            this.Item.SellIn = -1;
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(80, Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ShouldNotAlterSellIn()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(10, Item.SellIn);
        }
    }

    public class GivenABackstagePass : TestBase
    {
        public GivenABackstagePass()
        {
            SetupItem("Backstage passes to a TAFKAL80ETC concert", 10, 10);
        }

        [Fact]
        public void WhenSellInIsGreaterThan10_ShouldIncreaseQualityBy1()
        {
            this.Item.SellIn = 11;
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(10, Item.SellIn);
            Assert.Equal(11, Item.Quality);
        }

        [Fact]
        public void WhenSellInIsBetween10And6_ShouldIncreaseQualityBy2()
        {
            this.Item.SellIn = 10;
            this.QualityControl.UpdateQuality(Items);
            this.QualityControl.UpdateQuality(Items);
            this.QualityControl.UpdateQuality(Items);
            this.QualityControl.UpdateQuality(Items);
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(5, Item.SellIn);
            Assert.Equal(20, Item.Quality);
        }

        [Fact]
        public void WhenSellInIs5OrLess_ShouldIncreaseQualityBy3()
        {
            this.Item.SellIn = 5;
            this.QualityControl.UpdateQuality(Items);
            this.QualityControl.UpdateQuality(Items);
            this.QualityControl.UpdateQuality(Items);
            this.QualityControl.UpdateQuality(Items);
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(0, Item.SellIn);
            Assert.Equal(25, Item.Quality);
        }

        [Fact]
        public void WhenSellInIs5OrLessAndQualityIs48_ShouldOnlyIncreaseQualityBy2()
        {
            this.Item.SellIn = 5;
            this.Item.Quality = 48;
            this.QualityControl.UpdateQuality(Items);
            
            Assert.Equal(4, Item.SellIn);
            Assert.Equal(50, Item.Quality);
        }

        [Fact]
        public void WhenSellInIs0_ShouldSetQualityTo0()
        {
            this.Item.SellIn = 0;
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(-1, Item.SellIn);
            Assert.Equal(0, Item.Quality);
        }

        [Fact]
        public void WhenQualityIs50_ShouldNotIncreaseQuality()
        {
            this.Item.Quality = 50;
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(50, Item.Quality);
        }
    }

    public class GivenAConjuredItem : TestBase
    {
        public GivenAConjuredItem()
        {
            this.SetupItem("Conjured Mana Cake", 10, 10);
        }

        [Fact]
        public void WhenSellInIsPositive_ShouldDecreaseQualityBy2()
        {
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(8, Item.Quality);
        }

        [Fact]
        public void WhenSellInIsZero_ShouldDecreaseQualityBy4()
        {
            this.Item.SellIn = 0;
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(6, Item.Quality);
        }

        [Fact]
        public void WhenQualityIsZero_ShouldNotAlterQuality()
        {
            this.Item.Quality = 0;
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(0, Item.Quality);
        }

        [Fact]
        public void WhenQualityIs1_ShouldSetQualityTo0()
        {
            this.Item.Quality = 0;
            this.QualityControl.UpdateQuality(Items);

            Assert.Equal(0, Item.Quality);
        }
    }
}