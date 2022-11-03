using System;
using System.Collections.Generic;
using ApprovalUtilities.Utilities;

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
            gildedFactor.Add("Conjured Item", new ConjuredItemProcess());
        }

        public void UpdateQuality() =>
            Items.ForEach(item => 
                GetProcessor(item.Name)
                    .Process(item));

        private IGuildedRoseItemProcess GetProcessor(string name)
        {
            if(!gildedFactor.TryGetValue(name, out var itemProcess))
                itemProcess = new RegularItemProcess();

            return itemProcess;
        }
    }
}
