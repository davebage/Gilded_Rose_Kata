namespace csharp
{
    public class RegularItemProcess : GildedRoseProduct
    {
        public void Process(Item item)
        {
            DecreaseSellIn(item);

            DecreaseQuality(item);
            
            if (item.SellIn < 0)
                DecreaseQuality(item);
        }
    }
}