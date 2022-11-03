namespace csharp
{
    public class ConjuredItemProcess : GildedRoseProduct, IGuildedRoseItemProcess
    {
        public void Process(Item item)
        {
            DecreaseSellIn(item);

            DecreaseQuality(item);
            DecreaseQuality(item);
        }
    }
}