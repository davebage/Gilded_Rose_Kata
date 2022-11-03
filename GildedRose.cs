using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        Dictionary<string, IGuildedRoseItemProcess> gildedFactor = new Dictionary<string, IGuildedRoseItemProcess>();

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;

            gildedFactor.Add("Aged Brie", new AgedBrieItemProcess());
            gildedFactor.Add("Backstage passes to a TAFKAL80ETC concert", new BackstagePassProcess());
            gildedFactor.Add("Sulfuras, Hand of Ragnaros", new LegendaryItemProcess());
            gildedFactor.Add("Regular", new RegularItemProcess());

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                IGuildedRoseItemProcess itemProcess;
                if (!gildedFactor.TryGetValue(item.Name, out itemProcess))
                    itemProcess = new RegularItemProcess();

                itemProcess.Process(item);
            }
        }
    }
}
