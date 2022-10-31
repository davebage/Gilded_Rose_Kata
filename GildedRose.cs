using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        const int REGULAR_ITEM_MAXIMUM_QUALITY = 50;
        const int REGULAR_ITEM_MINIMUM_QUALITY = 0;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if(Items[i].Name == "Sulfuras, Hand of Ragnaros")
                    continue;

                if (Items[i].Name == "Aged Brie"
                    || Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    IncreaseItemQuality(Items[i]);

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            IncreaseItemQuality(Items[i]);
                        }

                        if (Items[i].SellIn < 6)
                        {
                            IncreaseItemQuality(Items[i]);
                        }
                    }
                }
                else
                {
                    DecreaseItemQuality(Items[i]);
                }

                DecreaseSellIn(Items[i]);
                
                EndOfDayProcess(Items[i]);
            }
        }

        private void EndOfDayProcess(Item item)
        {
            if (item.SellIn >= 0) return;

            if (item.Name == "Aged Brie")
            {
                IncreaseItemQuality(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0;
            }
            else
            {
                DecreaseItemQuality(item);
            }
        }

        private void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        private void DecreaseItemQuality(Item item)
        {
            if(item.Quality > REGULAR_ITEM_MINIMUM_QUALITY)
                item.Quality--;
        }

        private void IncreaseItemQuality(Item item)
        {
            if (item.Quality < REGULAR_ITEM_MAXIMUM_QUALITY)
                item.Quality++;
        }
    }
}
