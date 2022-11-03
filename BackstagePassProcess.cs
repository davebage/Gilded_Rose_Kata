namespace csharp
{
    public class BackstagePassProcess : GildedRoseProduct
    {
        const int REGULAR_ITEM_MAXIMUM_QUALITY = 50;

        public void Process(Item item)
        {
            DecreaseSellIn(item);

            if (item.Quality < REGULAR_ITEM_MAXIMUM_QUALITY)
                item.Quality++;

            if (item.SellIn < 11 && item.Quality < REGULAR_ITEM_MAXIMUM_QUALITY)
            {
                item.Quality++;
            }

            if (item.SellIn < 6 && item.Quality < REGULAR_ITEM_MAXIMUM_QUALITY)
            {
                item.Quality++;
            }

            if (item.SellIn < 0)
                item.Quality = 0;
        }
    }
}