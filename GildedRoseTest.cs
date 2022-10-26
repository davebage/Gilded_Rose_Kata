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
    }
}
