namespace csharp
{
    public abstract class GildedRoseProduct
    {
        protected void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }
    }
}