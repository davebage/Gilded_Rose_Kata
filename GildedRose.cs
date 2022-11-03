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

                DecreaseSellIn(item);
                if (item.Name == "Aged Brie")
                {
                    var agedBrieItemProcess  = new AgedBrieItemProcess();
                    agedBrieItemProcess.Process(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    var backstagePassProcess = new BackstagePassProcess();
                    backstagePassProcess.Process(item);

                }
                else
                {
                    DecreaseItemQuality(item);
                    if (item.SellIn < 0)
                        DecreaseItemQuality(item);

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
