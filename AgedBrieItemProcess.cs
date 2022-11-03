namespace csharp
{
    public class AgedBrieItemProcess : GildedRoseProduct, IGuildedRoseItemProcess
    {
        public void Process(Item item)
        {
            DecreaseSellIn(item);

            IncreaseQuality(item);
            
            if (item.SellIn < 0)
                IncreaseQuality(item);
        }
    }
}