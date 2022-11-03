namespace csharp
{
    public class RegularItemProcess
    {
        const int REGULAR_ITEM_MINIMUM_QUALITY = 0;
        
        public void Process(Item item)
        {
            if(item.Quality > REGULAR_ITEM_MINIMUM_QUALITY)
                item.Quality--;
            
            if (item.SellIn < 0 && item.Quality > REGULAR_ITEM_MINIMUM_QUALITY)
                item.Quality--;
        }
    }
}