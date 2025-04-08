using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void TestNormalDegradation()
        {
            var Items = new List<Item> { new Item { Name = "normalItem", SellIn = 10, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(19, Items[0].Quality);
        }

        [Fact]
        public void TestNormalDegradationNegativeSellIn()
        {
            var Items = new List<Item> { new Item { Name = "normalItem", SellIn = -1, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(18, Items[0].Quality);
        }

        [Fact]
        public void TestNormalDegradationMinQuality()
        {
            var Items = new List<Item> { new Item { Name = "normalItem", SellIn = 10, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void TestGoodWineDegradation()
        {
            var Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 10, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(21, Items[0].Quality);
        }

        [Fact]
        public void TestGoodWineDegradationNegativeSellin()
        {
            var Items = new List<Item> { new Item { Name = "Good Wine", SellIn = -1, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(22, Items[0].Quality);
        }

        [Fact]
        public void TestGoodWineDegradationMaxQuality()
        {
            var Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 10, Quality = 50 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void TestLegendaryDegradation()
        {
            var Items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 10, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(10, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void TestBackStagePassDegradation()
        {
            var Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 15, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(14, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void TestBackStagePassDegradationSellInBetween5And10()
        {
            var Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 7, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(6, Items[0].SellIn);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void TestBackStagePassDegradationSellInBetween0And5()
        {
            var Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 3, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        public void TestBackStagePassDegradationSellIn0()
        {
            var Items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 0, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void TestSmellyDegradation()
        {
            var Items = new List<Item> { new Item { Name = "Duplicate Code", SellIn = 10, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(18, Items[0].Quality);
        }
    }
}