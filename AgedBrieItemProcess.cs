namespace csharp
{
    public class AgedBrieItemProcess
    {
        const int REGULAR_ITEM_MAXIMUM_QUALITY = 50;
        
        public void Process(Item item)
        {
            if (item.Quality < REGULAR_ITEM_MAXIMUM_QUALITY)
                item.Quality++;
            
            if (item.SellIn < 0 && item.Quality < REGULAR_ITEM_MAXIMUM_QUALITY)
                item.Quality++;
            
            // item.SellIn--;
        }
    }
}