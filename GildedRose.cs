using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
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
                    var regularItemProcess = new RegularItemProcess();
                    regularItemProcess.Process(item);
                }
            }
        }
    }
}
