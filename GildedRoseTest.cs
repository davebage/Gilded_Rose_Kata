using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Update_Quality_For_Mongoose_Elixir_Reduce_Sell_In_And_Quality_By_One()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Elixir of the Mongoose", Items[0].Name);
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(6, Items[0].Quality);
        }

        [Test]
        public void Update_Quality_For_Aged_Brie_Reduce_Sell_In_And_Increase_Quality()
        {
            // Arrange 
            var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 7 } };
            var app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert 
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        [TestCase(50)]
        [TestCase(51)]
        [TestCase(52)]
        public void Update_Quality_For_Aged_Brie_Reduce_Sell_In(int quality)
        {
            // Arrange 
            var Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = quality } };
            var app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert 
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(quality, Items[0].Quality);
        }

        [Test]
        [TestCase(10, 8, 10)]
        [TestCase(5, 8, 11)]
        [TestCase(14, 8, 9)]
        [TestCase(0, 8, 0)]
        public void Update_Quality_For_Backstage_Pass_Reduce_Sell_In_And_Increase_Quality(
            int sellIn, 
            int actualQuality,
            int expectedQuality)
        {
            // Arrange 
            var Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = sellIn,
                    Quality = actualQuality
                }
            };
            var app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert 
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(sellIn - 1, Items[0].SellIn);
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        [TestCase(0, 5)]
        [TestCase(-1, 2)]
        public void Quality_Degrades_By_Two_When_Past_Sell_By_Date(int sellIn, int actualQuality)
        {
            var Items = new List<Item>
            {
                new Item
                {
                    Name = "Apple",
                    SellIn = sellIn,
                    Quality = actualQuality
                }
            };
            var app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert 
            Assert.AreEqual("Apple", Items[0].Name);
            Assert.AreEqual(sellIn - 1, Items[0].SellIn);
            Assert.AreEqual(actualQuality-2, Items[0].Quality);
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void Quality_Of_An_Item_Never_Gets_Below_Zero(int sellIn)
        {
            var Items = new List<Item>()
            {
                new Item()
                {
                    Name = "Apple",
                    SellIn = sellIn,
                    Quality = 0
                }
            };
            var app = new GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            Assert.AreEqual("Apple", Items[0].Name);
            Assert.AreEqual(sellIn - 1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
