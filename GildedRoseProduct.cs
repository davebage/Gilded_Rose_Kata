namespace csharp
{
    public abstract class GildedRoseProduct
    {
        const int REGULAR_ITEM_MAXIMUM_QUALITY = 50;
        const int REGULAR_ITEM_MINIMUM_QUALITY = 0;

        protected virtual int DECREASE_QUALITY_FACTOR => 1;
    
        protected void IncreaseQuality(Item item)
        {
            if (item.Quality < REGULAR_ITEM_MAXIMUM_QUALITY)
                item.Quality++;
        }
        
        protected void DecreaseQuality(Item item)
        {
            if (item.Quality - DECREASE_QUALITY_FACTOR > REGULAR_ITEM_MINIMUM_QUALITY)
            {
                item.Quality -= DECREASE_QUALITY_FACTOR;
                return;
            }

            item.Quality = REGULAR_ITEM_MINIMUM_QUALITY;
        }

        protected void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}