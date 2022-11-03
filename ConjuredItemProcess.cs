namespace csharp
{
    public class ConjuredItemProcess : GildedRoseProduct, IGuildedRoseItemProcess
    {
        protected override int DECREASE_QUALITY_FACTOR => 2;

        public void Process(Item item)
        {
            DecreaseSellIn(item);

            DecreaseQuality(item);
        }
    }
}