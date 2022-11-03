namespace csharp
{
    public class BackstagePassProcess : GildedRoseProduct, IGuildedRoseItemProcess
    {
        public void Process(Item item)
        {
            DecreaseSellIn(item);

            IncreaseQuality(item);

            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 0)
                item.Quality = 0;
        }
    }
}