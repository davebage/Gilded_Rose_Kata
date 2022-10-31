﻿using System.Collections.Generic;
using System.Linq;

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
            foreach (var item in Items)
            {
                if(item.Name == "Sulfuras, Hand of Ragnaros")
                    continue;

                if (item.Name == "Aged Brie")
                {
                    IncreaseItemQuality(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    IncreaseItemQuality(item);
                
                    if (item.SellIn < 11)
                    {
                        IncreaseItemQuality(item);
                    }

                    if (item.SellIn < 6)
                    {
                        IncreaseItemQuality(item);
                    }
                }
                else
                {
                    DecreaseItemQuality(item);
                }

                DecreaseSellIn(item);
                EndOfDayProcess(item);
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
