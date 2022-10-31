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
                if (Items[i].Name != "Aged Brie" 
                    && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert"
                    && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    DecreaseItemQuality(Items[i]);
                }
                else
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

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    DecreaseSellIn(Items[i]);
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name == "Aged Brie")
                    {
                        IncreaseItemQuality(Items[i]);
                    }
                    else if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" &&
                            Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        DecreaseItemQuality(Items[i]);
                    }
                }

                if (Items[i].SellIn < 0 && Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    Items[i].Quality = 0;
                }
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
